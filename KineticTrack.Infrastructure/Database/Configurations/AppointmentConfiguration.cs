using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("APPOINTMENTS");

        builder.HasKey(e => e.AppointmentId)
               .HasName("pk_appointments");

        builder.Property(e => e.ScheduledAt).IsRequired();
        builder.Property(e => e.Reason).IsRequired().HasMaxLength(500);
        builder.Property(e => e.Status)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(50);

        builder.HasOne(e => e.Patient)
               .WithMany()
               .HasForeignKey(e => e.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Practitioner)
               .WithMany()
               .HasForeignKey(e => e.PractitionerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CareEpisode)
               .WithMany()
               .HasForeignKey(e => e.CareEpisodeId)
               .OnDelete(DeleteBehavior.SetNull)
               .IsRequired(false);  // ← optionnel
    }
}