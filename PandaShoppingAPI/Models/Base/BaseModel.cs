using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models.Base
{
    public abstract class BaseModel<TEntity, TModel> : BaseModel<TEntity, TModel, int>
    {
    }

    public abstract class BaseModel<TEntity, TModel, TId> : IMapperProfile
    {
        public TId id { get; set; }

        public void CreateMappings(Profile profile,
             IConfiguration config)
        {
            IMappingExpression<TModel, TEntity> expression = 
                profile.CreateMap<TModel, TEntity> ();
            
            CustomMapping(expression.ReverseMap(), config);
        }

        public static TModel FromEntity(TEntity entity)
        {
            return Mapper.Map<TModel>(entity);
        }

        public TEntity ToEntity()
        {
            return Mapper.Map<TEntity>(this);
        }

        virtual protected void CustomMapping(IMappingExpression<TEntity, TModel> mappingExpression,
            IConfiguration config)
        {
        }
    }
}
