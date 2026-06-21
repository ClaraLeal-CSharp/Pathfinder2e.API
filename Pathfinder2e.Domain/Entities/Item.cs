namespace Pathfinder2e.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int price { get; set; }
    
    public int PlayerCharacterId { get; set; }
    public PlayerCharacter PlayerCharacter { get; set; }
}