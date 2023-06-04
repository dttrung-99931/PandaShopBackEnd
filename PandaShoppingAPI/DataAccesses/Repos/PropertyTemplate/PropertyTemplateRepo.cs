using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class PropertyTemplateRepo : BaseRepo<PropertyTemplate>, IPropertyTemplateRepo
    {
        public PropertyTemplateRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }

        public PropertyTemplate Get(int templateId, int propertyId)
        {
            return Where(temProperty => temProperty.templateId == templateId
                         && temProperty.propertyId == propertyId)
                .FirstOrDefault();
        }
    }
}
