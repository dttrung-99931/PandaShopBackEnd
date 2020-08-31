using AutoMapper;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Utils;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Services
{
    public abstract class BaseService<TRepo, TEntity, TRequestModel, TFilter> : 
        IBaseService<TEntity, TRequestModel, TFilter> 
        where TEntity: class
        where TRequestModel : class
        where TFilter: Filter
        where TRepo: IBaseRepo<TEntity>
    {
        protected TRepo _repo;
        public BaseService(TRepo repo)
        {
            _repo = repo;
        }

        public List<TEntity> Fill(TFilter filter, out Meta meta)
        {
            var filledEntities = Fill(filter);
            
            meta = Meta.ProcessAndCreate(filledEntities.Count(), filter);

            return MyUtil.Page(filledEntities, filter);
        }

        public virtual IQueryable<TEntity> Fill(TFilter filter)
        {
            return _repo.GetIQueryable();
        }

        public virtual void Delete(object id)
        {
            _repo.Delete(id);
        }

        public bool Exist(object id)
        {
            return _repo.GetById(id) != null;
        }

        public List<TEntity> GetAll()
        {
            return _repo.GetIQueryable().ToList();
        }
       
        public TEntity GetById(object id)
        {
            return _repo.GetById(id);
        }

        public virtual TEntity Insert(TRequestModel requestModel)
        {
            return _repo.Insert(Mapper.Map<TEntity>(requestModel));
        }

        public void Update(TRequestModel requestModel, object id)
        {
            _repo.Update(Mapper.Map<TEntity>(requestModel), id);
        }       
    }
}