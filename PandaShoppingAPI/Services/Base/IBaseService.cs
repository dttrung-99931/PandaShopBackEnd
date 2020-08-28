using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public interface IBaseService<T> where T: class
    {
        List<T> GetAll();

        T GetById(object id);

        void Delete(object id);

        T Insert(T entity);

        void Update(T entity, object id);

        bool Exist(object id);
    }
}
