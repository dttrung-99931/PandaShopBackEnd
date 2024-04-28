using Microsoft.EntityFrameworkCore.ChangeTracking;
using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        IQueryable<T> GetIQueryable(bool includeDeleted = false);

        List<T> GetAll(bool includeDeleted = false);

        IQueryable<T> Where(Expression<Func<T, bool>> condition, bool includeDeleted = false);
        bool Any(Expression<Func<T, bool>> condition, bool includeDeleted = false);

        T GetById(object id, bool includeDeleted = false);

        void Delete(object id);

        void DeleteRange(IEnumerable<object> ids);

        void DeleteRange(IEnumerable<T> entities);

        T Insert(T entity);

        List<T> InsertRange(IEnumerable<T> entites);

        void DeleteIf(Expression<Func<T, bool>> e, bool includeDeleted = false);
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

        void UpdateRange(IEnumerable<T> entities);

        public delegate void Change(T entity);

        void UpdateIf(Expression<Func<T, bool>> condition, Change change, bool includeDeleted = false);

        delegate void ChangeUpdate(EntityEntry<T> changeUpdate);

        // changeUpdate is used to change update.
        // For example: ignore update for some fields like created_at, ...
        void Update(T entity, object id, ChangeUpdate changeUpdate);
        
        delegate void Updater(T entity);
        void Update(object id, Updater updater);

        void ReplaceRange(IEnumerable<T> deleted, IEnumerable<T> inserted);

    }
}
