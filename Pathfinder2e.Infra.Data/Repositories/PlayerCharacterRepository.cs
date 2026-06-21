using Microsoft.EntityFrameworkCore;
using Pathfinder2e.Domain.Entities;
using Pathfinder2e.Domain.Interfaces;
using Pathfinder2e.Infra.Data.Context;

namespace Pathfinder2e.Infra.Data.Repositories;

public class PlayerCharacterRepository : IPlayerCharacterRepository
{
    private readonly AppDbContext _context;

    public PlayerCharacterRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerCharacter?> GetByIdAsync(int id)
    {
        return await _context.PlayerCharacters
            .Include(p => p.CharacterClass)
            .Include(p => p.Ancestry)
            .Include(p => p.Attributes)
            .Include(p => p.Statistics)
            .Include(p => p.Inventory)
            .Include(p => p.Feats)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<PlayerCharacter>> GetAllAsync()
    {
        return await _context.PlayerCharacters
            .Include(p => p.CharacterClass)
            .Include(p => p.Ancestry)
            .ToListAsync();
    }

    public async Task AddAsync(PlayerCharacter character)
    {
        await _context.PlayerCharacters.AddAsync(character);
    }

    public void Update(PlayerCharacter character)
    {
        _context.PlayerCharacters.Update(character);
    }

    public void Delete(PlayerCharacter character)
    {
        _context.PlayerCharacters.Remove(character);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
