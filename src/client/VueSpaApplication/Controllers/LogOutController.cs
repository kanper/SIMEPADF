using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{

    public class LogOutController : ControllerBase
    {

        //logout
        [HttpGet("logout")]
        public IActionResult Get()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return SignOut("Cookies", "oidc");
        }

    }
}
