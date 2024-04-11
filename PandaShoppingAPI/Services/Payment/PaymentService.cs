using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class PaymentService: IPaymentService
    {
        private IPaymentMethodRepo _paymentMethodRepo;

        public PaymentService(IPaymentMethodRepo paymentMethodRepo)
        {
            _paymentMethodRepo = paymentMethodRepo;
        }

    }

}
