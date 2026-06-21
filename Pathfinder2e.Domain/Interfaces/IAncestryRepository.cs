using Pathfinder2e.Domain.Entities;
namespace Pathfinder2e.Domain.Interfaces;

public interface IAncestryRepository
{
    Task<Ancestry?> GetByIdAsync(int id);
    Task<IEnumerable<Ancestry>> GetAllAsync();
    Task AddAsync(Ancestry ancestry);
}