using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models.Base
{
    public abstract class BaseModel<TEntity, TModel> : IMapperProfile
    {
        public void CreateMappings(Profile profile)
        {
            IMappingExpression<TEntity, TModel> expression = 
                profile.CreateMap<TEntity, TModel>();
            
            CustomMapping(expression.ReverseMap());
        }

        public static TModel FromEntity(TEntity entity)
        {
            return Mapper.Map<TModel>(entity);
        }

        public TEntity ToEntity()
        {
            return Mapper.Map<TEntity>(this);
        }

        virtual protected void CustomMapping(IMappingExpression<TModel, TEntity> mappingExpression)
        {
        }
    }
}
