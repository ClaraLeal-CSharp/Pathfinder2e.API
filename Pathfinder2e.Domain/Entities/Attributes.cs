namespace Pathfinder2e.Domain.Entities;

public class Attributes
{
    public int Id { get; set; }
    public int STR { get; set; }
    public int DEX { get; set; }
    public int CON { get; set; }
    public int INT { get; set; }
    public int WIN { get; set; }
    public int CHA { get; set; }
    
    public int PlayerCharacterId { get; set; }
    public PlayerCharacter PlayerCharacter { get; set; }
}