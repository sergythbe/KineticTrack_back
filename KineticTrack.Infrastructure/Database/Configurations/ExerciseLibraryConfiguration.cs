using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class ExerciseLibraryConfiguration : IEntityTypeConfiguration<ExerciseLibrary>
{
    public void Configure(EntityTypeBuilder<ExerciseLibrary> builder)
    {
        builder.ToTable("EXERCISE_LIBRARY");

        builder.HasKey(e => e.ExerciseLibraryId);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(250);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
        builder.Property(e => e.MediaUrl).HasMaxLength(500);
        builder.Property(e => e.Category).HasMaxLength(100);
    }
}