using Pathfinder2e.Domain.Entities;
namespace Pathfinder2e.Domain.Interfaces;

public interface IPlayerCaracterRepository
{
    Task<PlayerCharacter?> GetByIdAsync(int id);
    Task<IEnumerable<PlayerCharacter>> GetAllAsync();
    Task AddAsync(PlayerCharacter character);
    void Update(PlayerCharacter character);
    void Delete(PlayerCharacter character);
    Task<bool> SaveChangesAsync();
}