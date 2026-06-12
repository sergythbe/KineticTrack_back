using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class PractitionerConfiguration : IEntityTypeConfiguration<Practitioner>
{
    public void Configure(EntityTypeBuilder<Practitioner> builder)
    {
        builder.ToTable("PRACTITIONERS");

        builder.HasKey(e => e.PractitionerId);
        builder.Property(e => e.LicenseNumber).IsRequired().HasMaxLength(15);
        builder.Property(e => e.Speciality).IsRequired().HasMaxLength(250);

        // Relation 1-to-1 avec User
        builder.HasOne(e => e.User)
               .WithOne(e => e.Practitioner)
               .HasForeignKey<Practitioner>(e => e.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}