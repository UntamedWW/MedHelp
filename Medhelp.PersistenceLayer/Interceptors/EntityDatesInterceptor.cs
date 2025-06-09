using Medhelp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Medhelp.PersistenceLayer.Interceptors;

public class EntityDatesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            UpdateEntities(eventData.Context);
        }

        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateEntities(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext context)
    {
        var entries = context.ChangeTracker.Entries().ToList();
        foreach (var entry in entries.Where(entry => entry.State == EntityState.Added))
        {
            HandleAddedEntries(entry);
        }
    }

    private void HandleAddedEntries(EntityEntry entityEntry)
    {
        switch (entityEntry.Entity)
        {
            case Entity addedEntity:
                addedEntity.CreatedAt = DateTime.UtcNow;
                break;
        }
    }
}