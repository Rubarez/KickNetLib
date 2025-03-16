
using KickNetLib.Api.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace KickNetLib.Api.Extensions
{
    /// <summary>
    /// Extension methods for adding KickLib API services to the IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the Kick API services into the application's dependency injection container.
        /// This method binds the <see cref="IKickApi"/> interface to its <see cref="KickApi"/> implementation,
        /// enabling easy access to the Kick API through dependency injection throughout the application.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> where the services will be registered.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> used to configure the Kick API services (e.g., for authentication or API settings).</param>
        /// <returns>The updated <see cref="IServiceCollection"/> with Kick API services added and configured.</returns>
        public static IServiceCollection AddKickLibApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KickApiSettings>(configuration.GetSection("KickApiSettings"));

            return services
                .AddScoped<IKickApi>(provider =>
                {
                    var options = provider.GetRequiredService<IOptions<KickApiSettings>>().Value;
                    return new KickApi(options);
                });
        }
    }
}
