using Microsoft.EntityFrameworkCore;
using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected EcommerceDBContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepo(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual void Delete(object id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                Save();
            }
            else throw new KeyNotFoundException("Not found entity with id " + id);
        }


        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetIQueryable()
        {
            return _dbSet;
        }

        public virtual T Insert(T entity)
        {
            entity = _dbSet.Add(entity).Entity;
            Save();
            return entity;
        }

        protected void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                handleDbUpdateEx(dbEx);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void handleDbUpdateEx(DbUpdateException dbEx)
        {
            if (dbEx.InnerException != null)
            {
                // dbEx.InnerException.InnerException is SqlException
                if (dbEx.InnerException.InnerException != null)
                    throw new Exception(dbEx.InnerException.InnerException.Message,
                                        dbEx.InnerException.InnerException);
                else throw new Exception(dbEx.InnerException.Message, dbEx.InnerException);
            }
            else throw new Exception(GetDbUpdateErrMsgs(dbEx), dbEx);
        }

        // Get common error messages from DbUpdateException
        private string GetDbUpdateErrMsgs(DbUpdateException dbEx)
        {
            return dbEx.Message;
        }

        public virtual void Update(T entityToUpdate, object id)
        {
            var originEntity = GetById(id);

            _dbContext.Entry(originEntity).State = EntityState.Detached;

            _dbContext.Update(entityToUpdate);

            //var entry = _dbContext.Entry(entityToUpdate);

            //Type type = typeof(T);

            //PropertyInfo[] properties = type.GetProperties();

            // Check if there are no changes on Primitive properties
            // of entityToUpdate with originEnttity
            // then mark it as unmodified
            //foreach (PropertyInfo property in properties)
            //{
            //    if (property.propertytype.isprimitive &&
            //        property.getvalue(entitytoupdate, null) != property.getvalue(originentity, null))
            //    {
            //        entry.property(property.name).ismodified = true;
            //    }
            //}

            Save();
        }

        public void DeleteRange(List<object> ids)
        {
            List<T> deletedEntities = new List<T>();
            foreach (int id in ids)
            {
                var entity = GetById(id);
                if (entity != null) deletedEntities.Add(entity);
            }
            _dbSet.RemoveRange(deletedEntities);
            Save();
        }

        public List<T> InsertRange(List<T> entites)
        {
            _dbSet.AddRange(entites);
            Save();
            return entites;
        }

        public void DeleteIf(Expression<Func<T, bool>> e)
        {
            List<T> deletedEntities = _dbSet.Where(e).ToList();
            _dbSet.RemoveRange(deletedEntities);
            Save();
        }

        public void LoadNavigationProperty<TRef>(T entity, Expression<Func<T, TRef>> exp) where TRef : class
        {
            _dbContext.Entry(entity).Reference(exp).Load();
        }

        public void UpdateRange(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
            Save();
        }

        public void UpdateIf(Expression<Func<T, bool>> condition, IBaseRepo<T>.Change change)
        {
            var entities = _dbSet.Where(condition).ToList();
            foreach (var entity in entities)
            {
                change.Invoke(entity);
            }
            UpdateRange(entities);
        }

        // changeUpdate is used to change update.
        // For example: ignore update for some fields like created_at, ...
        public void Update(T entity, object id, IBaseRepo<T>.ChangeUpdate changeUpdate)
        {
            var originEntity = GetById(id);

            _dbContext.Entry(originEntity).State = EntityState.Detached;

            var updatedEntry = _dbContext.Update(entity);

            changeUpdate.Invoke(updatedEntry);

            Save();
        }

        public void LoadNavigationCollection<TRef>(
            T entity, Expression<Func<T, IEnumerable<TRef>>> exp) where TRef : class
        {
            _dbContext.Entry(entity).Collection(exp).Load();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> condition)
        {
            return _dbSet.Where(condition);
        }

        public void Update(object id, IBaseRepo<T>.Updater updater)
        {
            var entity = GetById(id);

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            updater.Invoke(entity);

            Update(entity, id);
        }

        public bool Any(Expression<Func<T, bool>> condition)
        {
            return _dbSet.Any(condition);
        }
    }
}
