using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathfinder2e.Domain.Entities;

namespace Pathfinder2e.Infra.Data.EntitiesConfiguration;

public class PlayerCharacterConfiguration : IEntityTypeConfiguration<PlayerCharacter>
{
    public void Configure(EntityTypeBuilder<PlayerCharacter> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Level)
            .IsRequired()
            .HasDefaultValue(10);

        // Relacionamento 1:N - Classe
        builder.HasOne(p => p.CharacterClass)
            .WithMany(c => c.PlayerCharacters)
            .HasForeignKey(p => p.CharacterClassId)
            .OnDelete(DeleteBehavior.Restrict); // Impede deletar uma classe se houver personagens nela

        // Relacionamento 1:N - Ancestralidade
        builder.HasOne(p => p.Ancestry)
            .WithMany(a => a.PlayerCharacters)
            .HasForeignKey(p => p.AncestryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento 1:1 - Attributes
        builder.HasOne(p => p.Attributes)
            .WithOne(a => a.PlayerCharacter)
            .HasForeignKey<Attributes>(a => a.PlayerCharacterId)
            .OnDelete(DeleteBehavior.Cascade); // Deletou o personagem, deleta os atributos junto

        // Relacionamento 1:1 - Statistics
        builder.HasOne(p => p.Statistics)
            .WithOne(s => s.PlayerCharacter)
            .HasForeignKey<Statistics>(s => s.PlayerCharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento 1:N - Itens do Inventário
        builder.HasMany(p => p.Inventory)
            .WithOne(i => i.PlayerCharacter)
            .HasForeignKey(i => i.PlayerCharacterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}