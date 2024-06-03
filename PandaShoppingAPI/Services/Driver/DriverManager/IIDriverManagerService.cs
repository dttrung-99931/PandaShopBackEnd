using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    // Service manage drivers. Including: finding drivers to assign a ready ship delivery, ,...   
    public interface IDriverManagerService 
    {
        List<DeliveryResponse> GetUpcomingDeliveries(UpcomingDeliveriesFilter filter, out Meta meta);
    }
}
