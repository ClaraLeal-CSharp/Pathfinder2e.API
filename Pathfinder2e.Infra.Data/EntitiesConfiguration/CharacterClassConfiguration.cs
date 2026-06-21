using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathfinder2e.Domain.Entities;

namespace Pathfinder2e.Infra.Data.EntitiesConfiguration;

public class CharacterClassConfiguration : IEntityTypeConfiguration<CharacterClass>
{
    public void Configure(EntityTypeBuilder<CharacterClass> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.HitPoints)
            .IsRequired();

        // Configura a tabela associativa N:N entre Classes e Talentos
        builder.HasMany(c => c.AvailableFeats)
            .WithMany(f => f.AllowedClasses)
            .UsingEntity(j => j.ToTable("ClassAvailableFeats"));
    }
}