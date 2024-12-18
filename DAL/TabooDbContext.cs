using Microsoft.EntityFrameworkCore;
using TabooGameApi.Entities;

namespace TabooGameApi.DAL;

public class TabooDbContext : DbContext
{

    public TabooDbContext(DbContextOptions opt) : base(opt)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabooDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Language> Languages { get; set; }
}
