namespace Pathfinder2e.Domain.Entities;

public class Statistics
{
    public int Id { get; set; }
    public int MaxHp { get; set; }
    public int CurrentHp { get; set; }
    public int ArmorClass { get; set; }
    public int Fortitude { get; set; }
    public int Reflex { get; set; }
    public int Will { get; set; }
    
    public int PlayerCharacterId { get; set; }
    public PlayerCharacter PlayerCharacter { get; set; }
}