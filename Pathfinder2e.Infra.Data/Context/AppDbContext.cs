using Microsoft.EntityFrameworkCore;
using Pathfinder2e.Domain.Entities;

namespace Pathfinder2e.Infra.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
    public DbSet<Attributes> Attributes { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<Ancestry> Ancestries { get; set; }
    public DbSet<Feat> Feats { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
