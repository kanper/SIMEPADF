using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Model.Domain;

namespace Auth.Services
{
    public class ProfileService : IProfileService
    {
        protected UserManager<Usuario> _userManager;

        public ProfileService(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.NombrePersonal),
                new Claim(ClaimTypes.Surname, user.ApellidoPersonal),
                new Claim(ClaimTypes.Country, user.Pais),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Actor, user.Cargo),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Role, user.RolId)
            };

            context.IssuedClaims.AddRange(claims);

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;

            // su logica para validar  si el usuario tiene acceso el sistema o no 
            // context.IsActive = !user.IsBanned;

            context.IsActive = true;

            return Task.FromResult(0);
        }
    }
}
