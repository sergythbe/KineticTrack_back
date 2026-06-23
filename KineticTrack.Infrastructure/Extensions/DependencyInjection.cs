using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KineticTrack.Domain.Repositories;
using KineticTrack.Infrastructure.Database.Context;
using KineticTrack.Infrastructure.Repositories;

namespace KineticTrack.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
       
        services.AddDbContext<KineticTrackDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                   .UseSnakeCaseNamingConvention());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<ICareEpisodeRepository, CareEpisodeRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();


        return services;
    }
}