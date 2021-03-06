using Business.Servises;
using Business.Servises.IServices;
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
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();

            return services;
        }

        public static IServiceCollection AddServises(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrganizerService, OrganizerService>();
            services.AddScoped<ISpeakerService, SpeakerService>();
            services.AddScoped<IEventService, EventService>();

            return services;
        }
    }
}
