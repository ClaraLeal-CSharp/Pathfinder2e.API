using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathfinder2e.Domain.Entities;

namespace Pathfinder2e.Infra.Data.EntitiesConfiguration;

public class AncestryConfiguration : IEntityTypeConfiguration<Ancestry>
{
    public void Configure(EntityTypeBuilder<Ancestry> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.HitPoints)
            .IsRequired();

        builder.Property(a => a.Speed)
            .IsRequired();

        // Configura a tabela associativa N:N entre Ancestralidades e Talentos
        builder.HasMany(a => a.AvailableFeats)
            .WithMany(f => f.AllowedAncestries)
            .UsingEntity(j => j.ToTable("AncestryAvailableFeats"));
    }
}