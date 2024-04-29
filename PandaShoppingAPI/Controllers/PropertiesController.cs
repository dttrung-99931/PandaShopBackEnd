using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class PropertiesController : CrudApiController<Property, PropertyModel,
            PropertyResponseModel, IPropertyService, PropertyFilter>
    {

        public PropertiesController(IPropertyService service) : base(service)
        {
        }
    }
}