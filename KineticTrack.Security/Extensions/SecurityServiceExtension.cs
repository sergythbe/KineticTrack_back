using Microsoft.Extensions.DependencyInjection;
using KineticTrack.Application.Security;
using KineticTrack.Security.Services.Tools;

namespace KineticTrack.Security.Extensions;

public static class SecurityServiceExtension
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasherService>();
    
        return services;
    }
}