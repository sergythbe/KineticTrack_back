using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;
using KineticTrack.Domain.Enums;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class CabinetMemberConfiguration : IEntityTypeConfiguration<CabinetMember>
{
    public void Configure(EntityTypeBuilder<CabinetMember> builder)
    {
        builder.ToTable("CABINET_MEMBER");

        // Clé composite : un user ne peut avoir qu'un rôle par cabinet
        builder.HasKey(e => new { e.UserId, e.CabinetId });

        builder.Property(e => e.RoleAtCabinet)
               .IsRequired()
               .HasConversion<string>()  // stocke "Admin", "Kine", "Secretaire" en DB
               .HasMaxLength(100);

        builder.Property(e => e.IsOwner).IsRequired();

        // Relations
        builder.HasOne(e => e.User)
               .WithMany(e => e.CabinetMemberships)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Cabinet)
               .WithMany(e => e.Members)
               .HasForeignKey(e => e.CabinetId)
               .OnDelete(DeleteBehavior.NoAction); // Cascade déjà défini côté Cabinet

        // --- DATA SEEDING ---
        builder.HasData(
            new CabinetMember(
                UserConfiguration.AdminId,
                CabinetConfiguration.CabinetId,
                CabinetRole.Admin,
                isOwner: true
            ),
            new CabinetMember(
                UserConfiguration.SecretaryId,
                CabinetConfiguration.CabinetId,
                CabinetRole.Secretary,
                isOwner: false
            )
        );
    }
}