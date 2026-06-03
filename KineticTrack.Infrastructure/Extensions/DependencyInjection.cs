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
        // 1. Enregistrement du DbContext avec SQL Server et ton package de Naming Conventions
        services.AddDbContext<KineticTrackDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                   .UseSnakeCaseNamingConvention()); // Plus besoin de mapper les colonnes à la main !

        // 2. Enregistrement de tes Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}