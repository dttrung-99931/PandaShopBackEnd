using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public partial class DriverService
    {
        public List<DeliveryResponse> GetUpcomingDeliveries(UpcomingDeliveriesFilter filter, out Meta meta)
        {
            //Driver driver = GetDriver(); 
            // TODO: Hanlde choose upcoming deliveries for driver
            // Base on delivery pickup lcoation, current driver location, driver's working place location
            IQueryable<Delivery> deliveries = _deliveryRepo
                .GetIQueryable()
                .Where(delivery => delivery.status == DeliveryStatus.Created);
            meta = Meta.ProcessAndCreate(deliveries.Count(), filter);
            List<Delivery> page = MyUtil.Page(deliveries, filter);
            return Mapper.Map<List<DeliveryResponse>>(page);
        }


    }
}
