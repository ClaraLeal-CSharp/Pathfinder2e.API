using Microsoft.EntityFrameworkCore;
using Pathfinder2e.Domain.Entities;
using Pathfinder2e.Domain.Interfaces;
using Pathfinder2e.Infra.Data.Context;

namespace Pathfinder2e.Infra.Data.Repositories;

public class CharacterClassRepository : ICharacterClassRepository
{
    private readonly AppDbContext _context;

    public CharacterClassRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CharacterClass?> GetByIdAsync(int id)
    {
        return await _context.CharacterClasses
            .Include(c => c.AvailableFeats)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<CharacterClass>> GetAllAsync()
    {
        return await _context.CharacterClasses.ToListAsync();
    }

    public async Task AddAsync(CharacterClass characterClass)
    {
        await _context.CharacterClasses.AddAsync(characterClass);
    }
}
