using System;
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

            // --- CONTRAINTES DE SÉCURITÉ & TAILLE ---
            // Plus besoin de HasColumnName ! Le package s'en occupe en arrière-plan.
            builder.Property(e => e.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(250);
            builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);

            // Contrainte d'unicité sur l'email
            builder.HasIndex(e => e.Email).IsUnique();

            // --- DATA SEEDING ---
            builder.HasData(
                new User(AdminId, "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G", "Admin", "KineticTrack", "admin@kinetictrack.be")
                {
                    IsActive = true,
                    IsPasswordChanged = true
                },
                new User(SecretaryId, "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G", "Marie", "Secrétaire", "marie@kinetictrack.be")
                {
                    IsActive = true,
                    IsPasswordChanged = true
                }
            );
        }
    }
}