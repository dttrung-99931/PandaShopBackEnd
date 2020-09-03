using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class PropertyService : BaseService<IPropertyRepo, Property, PropertyModel, PropertyFilter>, 
        IPropertyService
    {
        public PropertyService(IPropertyRepo repo) : base(repo)
        {
        }
    }
}
