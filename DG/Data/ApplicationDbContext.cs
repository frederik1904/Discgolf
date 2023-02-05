using DG.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        updateEntries(ChangeTracker);
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        updateEntries(ChangeTracker);
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        updateEntries(ChangeTracker);
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        updateEntries(ChangeTracker);
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    private void updateEntries(ChangeTracker changeTracker)
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
    }
}