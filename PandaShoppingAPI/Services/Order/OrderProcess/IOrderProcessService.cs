using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface IOrderProcessService
    {
        void StartProcessing(int orderId);
        void CompleteProcessing(int orderId);
        void RequestDelivery(int deliveryId);
        void RequestPartnerDelivery(RequestPartnerDeliveryModel requestModel);
    }
}
