using Business.IServices;
using Business.Servises;
using Data.Repositories;
using Data.Repositories.IRepositories;

namespace Meetup_API.Extantions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }

        public static IServiceCollection AddServises(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
