using MasterDance.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Data
{
    public static class Extensions
    {
        public static DbSet<TEntity> Upsert<TEntity>(this DbSet<TEntity> set, TEntity entity) where TEntity : class, IEntity
        {
            if (entity.Id == 0)
            {
                set.Add(entity);
            }
            else
            {
                set.Update(entity);
            }

            return set;
        }
    }
}