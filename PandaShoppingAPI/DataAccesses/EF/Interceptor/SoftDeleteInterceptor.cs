using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PandaShoppingAPI.DataAccesses.EF.Interceptor
{
	public class SoftDeleteInterceptor: SaveChangesInterceptor
	{
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context == null)
            {
                return result;
            }

            eventData.Context.ChangeTracker.Entries()
                .Where((entry) => entry is { State: EntityState.Deleted, Entity: BaseEntity entity })
                .ToList()
                .ForEach((entry) =>
                {
                    entry.State = EntityState.Modified;
                    (entry.Entity as BaseEntity).isDeleted = true;
                });
            return result;
        }
    }
}

