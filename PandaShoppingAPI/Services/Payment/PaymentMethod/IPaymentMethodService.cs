using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IPaymentMethodService: IBaseService<PaymentMethod, PaymentMethodModel, Filter>
    {
    }
}
