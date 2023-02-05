using DG.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DG.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<PlayerGameRel> PlayerGameRels { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Round> Rounds { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(entry => entry is { Entity: Entity, State: EntityState.Added or EntityState.Modified });
        foreach (var entry in entries)
        {
            var entity = ((Entity)entry.Entity);
            var currentTime = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entity.Created = currentTime;
                entity.LastChanged = currentTime;
                entity.Version = 1;
                entity.Id = Guid.NewGuid();
            }
            else
            {
                entity.LastChanged = currentTime;
                entity.Version++;
            }
        }

        return base.SaveChanges();
    }
}