using FluentValidation;
using KineticTrack.Application.Services;
using KineticTrack.Domain.Repositories;
using KineticTrack.Infrastructure;
using KineticTrack.Infrastructure.Repositories;
using KineticTrack.Security.Extensions;  
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddAuthorization();

        return services;
    }
}