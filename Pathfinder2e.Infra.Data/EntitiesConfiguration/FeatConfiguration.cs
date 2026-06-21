using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathfinder2e.Domain.Entities;

namespace Pathfinder2e.Infra.Data.EntitiesConfiguration;

public class FeatConfiguration : IEntityTypeConfiguration<Feat>
{
    public void Configure(EntityTypeBuilder<Feat> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(f => f.Description)
            .IsRequired()
            .HasMaxLength(1000); // Descrições de talentos de RPG podem ser longas

        // Relacionamento com o Personagem que COMPROU o talento (1 para N)
        builder.HasOne(f => f.PlayerCharacter)
            .WithMany(p => p.Feats)
            .HasForeignKey(f => f.PlayerCharacterId)
            .OnDelete(DeleteBehavior.Cascade); // Se deletar o personagem, apaga os talentos da ficha dele
    }
}