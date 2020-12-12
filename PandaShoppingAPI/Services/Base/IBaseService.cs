using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public interface IBaseService<TEntity, TRequestModel, TFilter>
        where TEntity: class
        where TRequestModel : class
        where TFilter: Filter
    {
        List<TEntity> Fill(TFilter filter, out Meta meta);

        List<TEntity> GetAll();

        TEntity GetById(object id);

        void Delete(object id);

        TEntity Insert(TRequestModel requestModel);

        void Update(TRequestModel requestModel, object id);

        bool Exist(object id);

        void SetUserIdentifier(UserIdentifier userIdentifier);
    }
}
