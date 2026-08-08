using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;

namespace KineticTrack.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public static readonly Guid AdminId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d");
        public static readonly Guid SecretaryId = Guid.Parse("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e");

        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Le package renomme la table automatiquement en "user", 
            // mais comme ton MLD impose explicitement "USER_" (avec l'underscore à la fin),
            // on garde juste cette ligne pour forcer le nom exact de la table :
            builder.ToTable("USERS");

            builder.HasKey(e => e.UserId);
            builder.Property(e => e.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(250);
            builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
            builder.Property(e => e.IsPasswordChanged).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();

            // Contrainte d'unicité sur l'email
            builder.HasIndex(e => e.Email).IsUnique();

            // --- DATA SEEDING ---
            builder.HasData(

                new User(
                    AdminId,
                    "aVZ5lhmja/hC7/cO/dMYWYOGfWYzFH4Is4X2UAazw9GRGBDCaaBdKcHUYP3TtXKo",
                    "Admin",
                    "KineticTrack",
                    "admin@kinetictrack.be",
                    new DateTime(2026, 6, 4, 10, 9, 27, 355, DateTimeKind.Utc),
                    isActive: true,           
                    isPasswordChanged: true
                    
                ),
                new User(
                    SecretaryId,
                    "aVZ5lhmja/hC7/cO/dMYWYOGfWYzFH4Is4X2UAazw9GRGBDCaaBdKcHUYP3TtXKo",
                    "Marie",
                    "Secrétaire",
                    "marie@kinetictrack.be",
                    new DateTime(2026, 6, 4, 10, 9, 27, 355, DateTimeKind.Utc),
                    isActive: true,
                    isPasswordChanged: true
                )
            );
        }
    }
}