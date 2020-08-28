using PandaShoppingAPI.DataAccesses.Repos;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepo<T> _repo;

        public BaseService(IBaseRepo<T> repo)
        {
            _repo = repo;
        }

        public virtual void Delete(object id)
        {
            _repo.Delete(id);
        }

        public bool Exist(object id)
        {
            return _repo.GetById(id) != null;
        }

        public List<T> GetAll()
        {
            return _repo.GetIQueryable().ToList();
        }
       
        public T GetById(object id)
        {
            return _repo.GetById(id);
        }

        public virtual T Insert(T entity)
        {
            return _repo.Insert(entity);
        }

        public void Update(T entity, object id)
        {
            _repo.Update(entity, id);
        }       
        
    }
}