using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class ProductInventoryController : BaseApiController<IProductInventoryService>
    {
        public ProductInventoryController(IProductInventoryService service) : base(service)
        {
        }


        [HttpGet("{productId}")]
        public ActionResult<ResponseWrapper> GetProductInventory(int productId)
        {
            return Handle(() =>
            {
                return ok_get(_service.GetProductInventory(productId));
            });
        }
    }
}

