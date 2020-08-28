using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public interface IBaseRepo<T> where T : class
    {
        IQueryable<T> GetIQueryable();

        T GetById(object id);

        void Delete(object id);

        void DeleteRange(List<object> ids);

        T Insert(T entity);

        List<T> InsertRange(List<T> entites);
        void DeleteIf(Expression<Func<T, bool>> e);
        void Update(T entity, object id);
        
        // Use in case of using nav properties of 
        // obj that just inserted. It's imposible to
        // use nav properties of object right after inserted
        void LoadNavigationProperty<TRef>(
            T entity,
            Expression<Func<T, TRef>> exp)
            where TRef : class;

        void LoadNavigationCollection<TRef>(
            T entity,
            Expression<Func<T, IEnumerable<TRef>>> exp)
            where TRef : class;

        void UpdateRange(List<T> entities);

        public delegate void Change(T entity);

        void UpdateIf(Expression<Func<T, bool>> condition, Change change);

        delegate void ChangeUpdate(EntityEntry<T> changeUpdate);

        // changeUpdate is used to change update.
        // For example: ignore update for some fields like created_at, ...
        void Update(T entity, object id, ChangeUpdate changeUpdate);

    }
}
