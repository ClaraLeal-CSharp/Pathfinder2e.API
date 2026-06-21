namespace Pathfinder2e.Domain.Entities;

public class Feat
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // O personagem que possui este talento na ficha dele
    public int PlayerCharacterId { get; set; }
    public PlayerCharacter PlayerCharacter { get; set; }
    
    // Relacionamentos Muitos para Muitos (N:N) genuínos
    public ICollection<CharacterClass> AllowedClasses { get; set; } = new List<CharacterClass>();
    public ICollection<Ancestry> AllowedAncestries { get; set; } = new List<Ancestry>();
}