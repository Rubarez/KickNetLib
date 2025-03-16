
using KickNetLib.Client.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KickNetLib.Client.Extensions
{
    /// <summary>
    /// Contains extension methods for registering services in the Dependency Injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the KickLib client to the service collection with a scoped lifetime.
        /// This enables the Kick client to be injected wherever needed in the application, ensuring 
        /// a single instance is used per request or scope.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> instance for configuring dependencies.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> used to configure the KickLib client (e.g., API settings or authentication).</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance with the KickLib client added.</returns>
        public static IServiceCollection AddKickLibClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KickWebHookSettings>(configuration.GetSection("KickWebHookSettings"));

            // Register the IKickClient interface to the KickClient implementation
            // with a scoped lifetime, meaning a new instance will be created per request.
            return services.AddScoped<IKickClient>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<KickClient>>();

                var options = provider.GetRequiredService<IOptions<KickWebHookSettings>>().Value;
                // Passing the 'verifySign' parameter to the KickClient constructor
                return new KickClient(logger, options.ValidateSender, options.PublicKeyPem);
            });
        }
    }
}
