
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Primitives;

namespace ToDo.Infrasturcture.Extensions;


public static class DbInterceptorsExtensions
{
    public static void UpdateAuditableEntities(this DbContext dbContext)
    {
        var entries = dbContext
            .ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            var now = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(e => e.CreatedOnUtc).CurrentValue = now;
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                if (entityEntry.Properties.Any(p => p.IsModified && p.Metadata.Name != nameof(IAuditableEntity.CreatedOnUtc)))
                {
                    entityEntry.Property(e => e.ModifiedOnUtc).CurrentValue = now;
                }
            }
        }
    }


}

