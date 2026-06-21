namespace Pathfinder2e.Domain.Entities;

public class Feat
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int PlayerCharacterId { get; set; }
    public PlayerCharacter PlayerCharacter { get; set; }
    
    public ICollection<CharacterClass> AllowedClasses { get; set; } = new List<CharacterClass>();
    public ICollection<Ancestry> AllowedAncestries { get; set; } = new List<Ancestry>();


}