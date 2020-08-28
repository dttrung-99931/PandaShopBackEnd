using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public interface IBaseService<TEntity, TFilter> where TEntity: class
    {
        List<TEntity> Fill(TFilter filter, out Meta meta);

        List<TEntity> GetAll();

        TEntity GetById(object id);

        void Delete(object id);

        TEntity Insert(TEntity entity);

        void Update(TEntity entity, object id);

        bool Exist(object id);
    }
}
