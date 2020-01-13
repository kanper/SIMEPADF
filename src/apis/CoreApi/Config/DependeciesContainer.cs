using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApi.Config
{
    public static class DependeciesContainer
    {
        public static void AddMyDependecies(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            #region Current User
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICurrentUserDTO, CurrentUserDTO>();
            #endregion
        }
    }
}
