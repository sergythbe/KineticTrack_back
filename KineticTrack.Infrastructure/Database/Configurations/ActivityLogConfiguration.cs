using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
{
    public void Configure(EntityTypeBuilder<ActivityLog> builder)
    {
        builder.ToTable("ACTIVITY_LOG");

        builder.HasKey(e => e.ActivityLogId);
        builder.Property(e => e.ExecutionDate).IsRequired();
        builder.Property(e => e.IsCompleted).IsRequired();
        builder.Property(e => e.PatientComment).HasMaxLength(500);
        builder.Property(e => e.EvaMetric).HasMaxLength(50);
        builder.Property(e => e.PractitionerNote).HasMaxLength(500);

        builder.HasOne(e => e.Exercise)
               .WithMany(e => e.ActivityLogs)
               .HasForeignKey(e => e.ExerciseLibraryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Protocol)
               .WithMany()
               .HasForeignKey(e => e.ProtocolId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Patient)
               .WithMany()
               .HasForeignKey(e => e.PatientId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}