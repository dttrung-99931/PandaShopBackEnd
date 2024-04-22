using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface IOrderProcessService
    {
        void StartProcessingOrder(int orderId);
        void CompleteProcessingOrder(int orderId);
    }
}
