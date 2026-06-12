using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("PATIENTS");

        builder.HasKey(e => e.PatientId);
        builder.Property(e => e.Birthdate).IsRequired();
        builder.Property(e => e.MedicalHistory).HasMaxLength(5000);
        builder.Property(e => e.Gender)
        .IsRequired()
        .HasConversion<string>()  
        .HasMaxLength(50);

        // Relation 1-to-1 avec User
        builder.HasOne(e => e.User)
               .WithOne(e => e.Patient)
               .HasForeignKey<Patient>(e => e.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // Relation 1-to-many avec CareEpisode
        builder.HasMany(e => e.CareEpisodes)
               .WithOne(e => e.Patient)
               .HasForeignKey(e => e.PatientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}