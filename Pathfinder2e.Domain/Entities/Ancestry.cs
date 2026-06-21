namespace Pathfinder2e.Domain.Entities;

public class Ancestry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int Speed { get; set; }
    
    public ICollection<PlayerCharacter> PlayerCharacters { get; set; } = new List<PlayerCharacter>();
    
    public ICollection<Feat> AvailableFeats { get; set; } = new List<Feat>();

}