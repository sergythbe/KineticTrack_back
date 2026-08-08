using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class ProtocolExerciseConfiguration : IEntityTypeConfiguration<ProtocolExercise>
{
    public void Configure(EntityTypeBuilder<ProtocolExercise> builder)
    {
        builder.ToTable("PROTOCOL_EXERCISE");

        builder.HasKey(e => new { e.ProtocolId, e.ExerciseLibraryId });

        builder.Property(e => e.Parameters).HasMaxLength(500);
        builder.Property(e => e.Order).HasMaxLength(50);

        builder.HasOne(e => e.Protocol)
               .WithMany(e => e.ProtocolExercises)
               .HasForeignKey(e => e.ProtocolId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Exercise)
               .WithMany(e => e.ProtocolExercises)
               .HasForeignKey(e => e.ExerciseLibraryId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}