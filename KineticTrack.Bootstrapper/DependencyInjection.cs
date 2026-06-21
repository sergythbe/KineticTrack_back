using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using KineticTrack.Application.Services; 
using KineticTrack.Infrastructure;       
using KineticTrack.Security.Extensions;  

namespace KineticTrack.Bootstrapper;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
       
        services.AddInfrastructureServices(configuration);
        services.AddSecurityServices(configuration);
        services.AddValidatorsFromAssemblyContaining<UserService>();         
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddAuthorization();

        return services;
    }
}