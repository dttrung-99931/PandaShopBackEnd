using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class PaymentMethodsController : CrudApiController2<PaymentMethod, PaymentMethodModel,
            PaymentMethodResponse, IPaymentMethodService, Filter>
    {
        public PaymentMethodsController(IPaymentMethodService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }
    }
}
