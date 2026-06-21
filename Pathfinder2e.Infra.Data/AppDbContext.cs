using Microsoft.EntityFrameworkCore;
using Pathfinder2e.Domain.Entities; // Ajuste para Pathfider2e se estiver sem o N

namespace Pathfinder2e.Infra.Data; // Ajuste o caminho se criou dentro de uma pasta /Data

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Mapeamento das tabelas do banco de dados
    public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
    public DbSet<Attributes> Attributes { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<Ancestry> Ancestries { get; set; }
    public DbSet<Feat> Feats { get; set; }
    public DbSet<Item> Items { get; set; }
}