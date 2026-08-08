using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class CabinetConfiguration : IEntityTypeConfiguration<Cabinet>
{
    public static readonly Guid CabinetId = Guid.Parse("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f");

    public void Configure(EntityTypeBuilder<Cabinet> builder)
    {
        builder.ToTable("CABINET");

        builder.HasKey(e => e.CabinetId);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(50);

        // Navigation : un cabinet a plusieurs membres
        builder.HasMany(e => e.Members)
               .WithOne(e => e.Cabinet)
               .HasForeignKey(e => e.CabinetId)
               .OnDelete(DeleteBehavior.Cascade);

        // DATA SEEDING 
        builder.HasData(
            new Cabinet(
                CabinetId,
                "Cabinet KineticTrack",
                "Rue de la Santé 1, 6000 Charleroi"
            )
        );
    }
}