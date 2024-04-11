using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class PaymentMethodService : BaseService<IPaymentMethodRepo, PaymentMethod, PaymentMethodModel, Filter>, IPaymentMethodService
    {
        public PaymentMethodService(IPaymentMethodRepo repo) : base(repo)
        {
        }
    }

}
