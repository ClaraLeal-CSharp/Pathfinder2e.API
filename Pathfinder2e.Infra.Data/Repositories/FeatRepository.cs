using Microsoft.EntityFrameworkCore;
using Pathfinder2e.Domain.Entities;
using Pathfinder2e.Domain.Interfaces;
using Pathfinder2e.Infra.Data.Context;

namespace Pathfinder2e.Infra.Data.Repositories;

public class FeatRepository : IFeatRepository
{
    private readonly AppDbContext _context;

    public FeatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Feat?> GetByIdAsync(int id)
    {
        return await _context.Feats.FindAsync(id);
    }

    public async Task<IEnumerable<Feat>> GetByClassIdAsync(int classId)
    {
        return await _context.Feats
            // Tradução: "Me traga os talentos onde QUALQUER uma das classes permitidas tenha o ID igual ao classId"
            .Where(f => f.AllowedClasses.Any(c => c.Id == classId))
            .ToListAsync();
    }

    public async Task<IEnumerable<Feat>> GetByAncestryIdAsync(int ancestryId)
    {
        return await _context.Feats
            // Tradução: "Me traga os talentos onde QUALQUER uma das ancestralidades permitidas tenha o ID igual ao ancestryId"
            .Where(f => f.AllowedAncestries.Any(a => a.Id == ancestryId))
            .ToListAsync();
    }


    public async Task AddAsync(Feat feat)
    {
        await _context.Feats.AddAsync(feat);
    }
}