using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KineticTrack.Domain.Entities;
using KineticTrack.Domain.Enums;

namespace KineticTrack.Infrastructure.Database.Configurations;

public class CareEpisodeConfiguration : IEntityTypeConfiguration<CareEpisode>
{
    public void Configure(EntityTypeBuilder<CareEpisode> builder)
    {
        builder.ToTable("CARE_EPISODE");

        builder.HasKey(e => e.CareEpisodeId);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(250);
        builder.Property(e => e.Status)
               .IsRequired()
               .HasConversion<string>()  // stocke "Open", "Closed", "Suspended"
               .HasMaxLength(50);
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasMany(e => e.Protocols)
               .WithOne(e => e.CareEpisode)
               .HasForeignKey(e => e.CareEpisodeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}