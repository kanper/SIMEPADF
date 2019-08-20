using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace DTO.DTO
{
    public interface ICurrentUserDTO
    {
        CurrentUser Get { get; }
    }
    public class CurrentUserDTO : ICurrentUserDTO
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserDTO( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser Get
        {
            get
            {
                var result = new CurrentUser();

                if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    return result;
                }

                var claims = _httpContextAccessor.HttpContext.User.Claims;

                if (claims.Any(x => x.Type.Equals("sub")))
                {
                    result.UserId = claims.Where(x => x.Type.Equals("sub")).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Name)))
                {
                    result.Nombre = claims.Where(x => x.Type.Equals(ClaimTypes.Name)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Surname)))
                {
                    result.Apellido = claims.Where(x => x.Type.Equals(ClaimTypes.Surname)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Email)))
                {
                    result.Email = claims.Where(x => x.Type.Equals(ClaimTypes.Email)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Actor)))
                {
                    result.Cargo = claims.Where(x => x.Type.Equals(ClaimTypes.Actor)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.MobilePhone)))
                {
                    result.Telefono = claims.Where(x => x.Type.Equals(ClaimTypes.MobilePhone)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Country)))
                {
                    result.Pais = claims.Where(x => x.Type.Equals(ClaimTypes.Country)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Role)))
                {
                    result.RolId = claims.Where(x => x.Type.Equals(ClaimTypes.Role)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals("access_token")))
                {
                    result.Token = claims.Where(x => x.Type.Equals("access_token")).First().Value;
                }

                return result;
            }
        }
    }

    public class CurrentUser
    {
        public string UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string RolId { get; set; }
        public string Token { get; set; }
    }
}
