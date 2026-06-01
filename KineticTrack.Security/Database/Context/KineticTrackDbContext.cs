using KineticTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Infrastructure.Database.Context;

public class KineticTrackDbContext : DbContext
{
    public KineticTrackDbContext(DbContextOptions<KineticTrackDbContext>options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KineticTrackDbContext).Assembly);
    }
}
