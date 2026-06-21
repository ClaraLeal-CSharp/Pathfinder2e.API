using Microsoft.EntityFrameworkCore;
using Pathfinder2e.Domain.Entities;
using Pathfinder2e.Domain.Interfaces;
using Pathfinder2e.Infra.Data.Context;

namespace Pathfinder2e.Infra.Data.Repositories;

public class AncestryRepository : IAncestryRepository
{
    private readonly AppDbContext _context;

    public AncestryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Ancestry?> GetByIdAsync(int id)
    {
        return await _context.Ancestries
            .Include(a => a.AvailableFeats)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Ancestry>> GetAllAsync()
    {
        return await _context.Ancestries.ToListAsync();
    }

    public async Task AddAsync(Ancestry ancestry)
    {
        await _context.Ancestries.AddAsync(ancestry);
    }
}