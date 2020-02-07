// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Auth.Models;
using DatabaseContext;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model.Domain;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Auth.Services;
using Microsoft.EntityFrameworkCore.Internal;
using EmailAddress = Auth.Models.EmailAddress;
using EmailMessage = Auth.Models.EmailMessage;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Auth.Controllers
{
    /// <summary>
    /// This sample controller implements a typical login/logout/provision workflow for local and external accounts.
    /// The login service encapsulates the interactions with the user data store. This data store is in-memory only and cannot be used for production!
    /// The interaction service provides a way for the UI to communicate with identityserver for validation and context retrieval
    /// </summary>
    [SecurityHeaders]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager; //Usuario
        private readonly SignInManager<Usuario> _signInManager;
        private readonly simepadfContext _simepadf;
        private readonly IConfiguration _configuration;
        private readonly TestUserStore _users;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;
        private readonly IEmailService _emailService;

        public AccountController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            simepadfContext simepadf,
            IConfiguration configuration,
            IEmailService emailService,
            TestUserStore users = null
        )
        {
            // if the TestUserStore is not in DI, then we'll just use the global users collection
            // this is where you would plug in your own custom identity management library (e.g. ASP.NET Identity)
            _users = users ?? new TestUserStore(TestUsers.Users);

            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
            _userManager = userManager;
            _signInManager = signInManager;
            _simepadf = simepadf;
            _configuration = configuration;
            _emailService = emailService;
        }

        /// <summary>
        /// Entry point into the login workflow
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            // build a model so we know what to show on the login page
            var vm = await BuildLoginViewModelAsync(returnUrl);

            if (vm.IsExternalLoginOnly)
            {
                // we only have one option for logging in and it's an external provider
                return RedirectToAction("Challenge", "External", new { provider = vm.ExternalLoginScheme, returnUrl });
            }

            return View(vm);
        }

        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user == null)
                {
                    ModelState.AddModelError("", AccountOptions.InvalidCredentialsErrorMessage);
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberLogin, true);
                    
                    if (!result.Succeeded)
                    {
                        if (_interaction.IsValidReturnUrl(model.ReturnUrl) || Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        return Redirect("~/");
                    }
                    ModelState.AddModelError(string.Empty, AccountOptions.InvalidCredentialsErrorMessage);
                }

            }
            // something went wrong, show form with error
            var vm = await BuildLoginViewModelAsync(model);
            return View(vm);
        }

        
        /// <summary>
        /// Show logout page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            // build a model so the logout page knows what to display
            var vm = await BuildLogoutViewModelAsync(logoutId);

            if (vm.ShowLogoutPrompt == false)
            {
                // if the request for logout was properly authenticated from IdentityServer, then
                // we don't need to show the prompt and can just log the user out directly.
                return await Logout(vm);
            }

            return View(vm);
        }

        /// <summary>
        /// Handle logout page postback
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LogoutInputModel model)
        {
            // build a model so the logged out page knows what to display
            var vm = await BuildLoggedOutViewModelAsync(model.LogoutId);

            if (User?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await HttpContext.SignOutAsync();

                // raise the logout event
                await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
            }

            // check if we need to trigger sign-out at an upstream identity provider
            if (vm.TriggerExternalSignout)
            {
                // build a return URL so the upstream provider will redirect back
                // to us after the user has logged out. this allows us to then
                // complete our single sign-out processing.
                string url = Url.Action("Logout", new { logoutId = vm.LogoutId });

                // this triggers a redirect to the external provider for sign-out
                return SignOut(new AuthenticationProperties { RedirectUri = url }, vm.ExternalAuthenticationScheme);
            }

            return View("LoggedOut", vm);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Recovery()
        {
            var model = new RecoveryInputModel {IsValidEmail = true, IsValidCode = true};
            return View(model);
        }

        [HttpPost]
        public IActionResult Recovery(RecoveryInputModel model, string button)
        {
            model.IsValidEmail = _simepadf.Usuario.Any(u => u.Email == model.Email);
            if (model.IsValidEmail && button == "send")
            {
                var recoveryCode = GenerateRandomRecoveryCode(10);
                SaveUserRecoveryCode(model.Email,recoveryCode);
                SendRecoveryEmail(model.Email, recoveryCode);
                model.ValidStart = DateTime.Now;
                model.ValidEnd = DateTime.Now.AddMinutes(30);
                return View("RecoveryEmail", new RecoveryInputModel(model.Email));
            }
            model.IsValidCode = _simepadf.Usuario.Any(u => u.Email == model.Email && u.RecoveryCode == model.Codigo);
            if (model.IsValidEmail && model.IsValidCode && button == "check")
            {
                return RedirectToAction("PasswordReset", new {email = model.Email,code = model.Codigo});
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PasswordReset(string email, string code)
        {
            return View(new PasswordResetInputModel(email,code));
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(PasswordResetInputModel model)
        {
            model.IsPasswordEquals = model.NewPassword.Equals(model.PasswordConfirmation);
            model.IsPasswordValid = model.NewPassword.Length >= 8 && 
                                    model.NewPassword.Any(char.IsUpper) && 
                                    model.NewPassword.Any(char.IsLower) && 
                                    model.NewPassword.Any(char.IsNumber) && 
                                    model.NewPassword.Any(char.IsLetter) && 
                                    !model.NewPassword.All(char.IsLetterOrDigit);
            if (model.IsPasswordEquals && model.IsPasswordValid && _simepadf.Usuario.Any(u => u.Email == model.Email && u.RecoveryCode == model.Code))
            {
                await ChangeUserPassword(model.Email, model.NewPassword);
                ResetUserRecoveryCode(model.Email);
                return View("RecoverySuccess");
            }

            return View("PasswordReset",model);
        }

        [HttpGet]
        public IActionResult RecoveryEmail()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RecoverySuccess()
        {
            return View();
        }

        /*****************************************/
        /* helper APIs for the AccountController */
        /*****************************************/
        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
            {
                var local = context.IdP == IdentityServer4.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                var vm = new LoginViewModel
                {
                    EnableLocalLogin = local,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                };

                if (!local)
                {
                    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
                }

                return vm;
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null ||
                            (x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }

        private async Task<LogoutViewModel> BuildLogoutViewModelAsync(string logoutId)
        {
            var vm = new LogoutViewModel { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };

            if (User?.Identity.IsAuthenticated != true)
            {
                // if the user is not authenticated, then just show logged out page
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            var context = await _interaction.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                // it's safe to automatically sign-out
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            // show the logout prompt. this prevents attacks where the user
            // is automatically signed out by another malicious web page.
            return vm;
        }

        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(logoutId);

            var vm = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (User?.Identity.IsAuthenticated == true)
            {
                var idp = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (idp != null && idp != IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync(idp);
                    if (providerSupportsSignout)
                    {
                        if (vm.LogoutId == null)
                        {
                            // if there's no current logout context, we need to create one
                            // this captures necessary info from the current logged in user
                            // before we signout and redirect away to the external IdP for signout
                            vm.LogoutId = await _interaction.CreateLogoutContextAsync();
                        }

                        vm.ExternalAuthenticationScheme = idp;
                    }
                }
            }

            return vm;
        }

        private string GenerateRandomRecoveryCode(int length)
        { 
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SaveUserRecoveryCode(string email, string recoveryCode)
        {
            try
            {
                var usuario = _simepadf.Usuario.Single(u => u.Email == email);
                usuario.RecoveryCode = recoveryCode;
                _simepadf.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void SendRecoveryEmail(string email, string recoveryCode)
        {
            try
            {
                var user = _simepadf.Usuario.Single(u => u.Email == email);
                EmailMessage message = new EmailMessage(); 
                message.ToAddresses.Add(new EmailAddress(user.Cargo, user.Email));
                message.FromAddresses.Add(new EmailAddress("SIMEPADF Servicio de Correo", "simepadf.ues@google.com")); 
                message.Content = $@"
    <div style='margin: auto; width: 100%;'>
        <div style='border: solid 2px steelblue;border-radius: 25px; padding: 0 20px 10px 20px;'>
                <div style='background-color: snow;border-radius: 25px 25px 0 0;'>
                        <img style='display: block;margin-left: auto;margin-right: auto;width: 15%;' alt='Logo' src='data:image/png;base64,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'/>
                    </div>                
                    <div style='background-color:white;padding: 40;border-radius: 0 0 25px 25px;font-family: Arial, Helvetica, sans-serif;'>
                        <h1 style='color:#0275d8;'>SIMEPADF</h1>
                        <br>
                        <h3>Recuperación de contraseñas:</h3>
                        <p><strong>Usuario:</strong> {user.NombrePersonal} {user.ApellidoPersonal}</p>
                        <p><strong>Cargo:</strong> {user.Cargo}</p>
                        <p><strong>País:</strong> {user.Pais}</p>
                        <p><strong>Código de Recuperación:</strong> {recoveryCode}</p>
                        <p>Este código es válido hasta {DateTime.Now.AddMinutes(30).ToString()}.</p>
                        <br><br>
                        <p>Fecha: {DateTime.Now.ToString()}</p>
                        <div style='margin-top: 20px;font-family: cursive;font-size: 8px;text-align: center;'>
                            <p>Se recomienda cambiar la contraseña una vez que tenga acceso al sistema.</p>
                            <p>SIMEPADF - {DateTime.Now.Year}</p>                        
                        </div>
                    </div>
        </div>
    </div>
                                "; 
                message.Subject = "SIMEPADF: Recuperación de contraseña"; 
                _emailService.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task ChangeUserPassword(string email, string password)
        {
            try
            {
                var user = _simepadf.Usuario.Single(u => u.Email == email);
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await  _userManager.ResetPasswordAsync(user, token, password);
                await _userManager.UpdateAsync(user);
                await _simepadf.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ResetUserRecoveryCode(string email)
        {
            try
            {
                _simepadf.Usuario.Single(u => u.Email == email).RecoveryCode = null;
                _simepadf.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}