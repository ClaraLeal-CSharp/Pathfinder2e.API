namespace Pathfinder2e.Domain.Entities;

public class PlayerCharacter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }

    public int CharacterClassId { get; set; }
    public CharacterClass CharacterClass { get; set; }

    public int AncestryId { get; set; }
    public Ancestry Ancestry { get; set; }

    public Attributes Attributes { get; set; }
    public Statistics Statistics { get; set; }
    public ICollection<Item> Inventory { get; set; } = new List<Item>();
    public ICollection<Feat> Feats { get; set; } = new List<Feat>();
}