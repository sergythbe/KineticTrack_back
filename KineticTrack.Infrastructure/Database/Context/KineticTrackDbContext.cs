using KineticTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KineticTrack.Infrastructure.Database.Context;

public class KineticTrackDbContext : DbContext
{
    public KineticTrackDbContext(DbContextOptions<KineticTrackDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Practitioner> Practitioners { get; set; } = null!;
    public DbSet<Cabinet> Cabinets { get; set; } = null!;
    public DbSet<CabinetMember> CabinetMembers { get; set; } = null!;
    public DbSet<CareEpisode> CareEpisodes { get; set; } = null!;
    public DbSet<Protocol> Protocols { get; set; } = null!;
    public DbSet<ExerciseLibrary> ExerciseLibraries { get; set; } = null!;
    public DbSet<ProtocolExercise> ProtocolExercises { get; set; } = null!;
    public DbSet<ActivityLog> ActivityLogs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KineticTrackDbContext).Assembly);
    }
}