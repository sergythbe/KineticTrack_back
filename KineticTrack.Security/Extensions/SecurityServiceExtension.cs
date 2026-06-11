using KineticTrack.Application.Security;
using KineticTrack.Security.Services;
using KineticTrack.Security.Services.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace KineticTrack.Security.Extensions;

public static class SecurityServiceExtension
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasherService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}