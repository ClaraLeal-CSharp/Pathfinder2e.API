using Microsoft.EntityFrameworkCore;
using Pathfinder2e.Domain.Entities;

namespace Pathfinder2e.Infra.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PlayerCharacter> PlayerCharacters { get; set; } = null!;
    public DbSet<Attributes> Attributes { get; set; } = null!;
    public DbSet<Statistics> Statistics { get; set; } = null!;
    public DbSet<CharacterClass> CharacterClasses { get; set; } = null!;
    public DbSet<Ancestry> Ancestries { get; set; } = null!;
    public DbSet<Feat> Feats { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerCharacter>()
            .HasOne(p => p.Attributes)
            .WithOne(a => a.PlayerCharacter)
            .HasForeignKey<Attributes>(a => a.PlayerCharacterId);

        modelBuilder.Entity<PlayerCharacter>()
            .HasOne(p => p.Statistics)
            .WithOne(s => s.PlayerCharacter)
            .HasForeignKey<Statistics>(s => s.PlayerCharacterId);

        modelBuilder.Entity<CharacterClass>()
            .HasMany(c => c.AvailableFeats)
            .WithMany(f => f.AllowedClasses);

        modelBuilder.Entity<Ancestry>()
            .HasMany(a => a.AvailableFeats)
            .WithMany(f => f.AllowedAncestries);
    }
}
