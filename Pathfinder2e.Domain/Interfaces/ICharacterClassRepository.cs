using Pathfinder2e.Domain.Entities;
namespace Pathfinder2e.Domain.Interfaces;

public interface ICharacterClassRepository
{
    Task<CharacterClass?> GetByIdAsync(int id);
    Task<IEnumerable<CharacterClass>> GetAllAsync();
    Task AddAsync(CharacterClass characterClass);
}