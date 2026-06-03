using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KineticTrack.Application.Services; 
using KineticTrack.Infrastructure;       
using KineticTrack.Security.Extensions;  

namespace KineticTrack.Bootstrapper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. On appelle l'extension de la couche Infrastructure (Base de données & Repositories)
            services.AddInfrastructureServices(configuration);

            // 2. On appelle l'extension de la couche Security (Argon2id PasswordHasher)
            services.AddSecurityServices();

            // 3. On enregistre les services de la couche Application (Logique métier)
            // (Puisque Application n'a pas de fichier d'extension propre, on l'enregistre directement ici)
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}