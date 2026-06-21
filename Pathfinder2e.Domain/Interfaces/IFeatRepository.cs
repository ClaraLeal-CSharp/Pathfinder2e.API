using Pathfinder2e.Domain.Entities;

namespace Pathfinder2e.Domain.Interfaces;

public interface IFeatRepository
{
    Task<Feat?> GetByIdAsync(int id);
    Task<IEnumerable<Feat>> GetByClassIdAsync(int classId);
    Task<IEnumerable<Feat>> GetByAncestryIdAsync(int ancestryId);
    Task AddAsync(Feat feat);
}