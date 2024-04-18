using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Services
{
    public abstract class BaseService<TRepo, TEntity, TRequestModel, TFilter> : 
        IBaseService<TEntity, TRequestModel, TFilter> 
        where TEntity: BaseEntity
        where TRequestModel : class
        where TFilter: Filter
        where TRepo: IBaseRepo<TEntity>
    {
        protected TRepo _repo;
        protected UserIdentifier User;

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
            return _repo.GetIQueryable()
                .Where((entity) => !entity.isDeleted);
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
            ValidateInsert(requestModel);
            return _repo.Insert(MapInsertEntity(requestModel));
        }

        protected virtual TEntity MapInsertEntity(TRequestModel requestModel)
        {
            return Mapper.Map<TEntity>(requestModel);
        }

        virtual protected void ValidateInsert(TRequestModel requestModel) { }

        virtual public void Update(TRequestModel requestModel, object id)
        {
            _repo.Update(Mapper.Map<TEntity>(requestModel), id);
        }

        public void SetUserIdentifier(UserIdentifier userIdentifier)
        {
            User = userIdentifier;
        }
    }
}