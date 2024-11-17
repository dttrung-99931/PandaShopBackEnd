using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public class DeliveryWithOrdersResponse
    {
        
        public int id { get; set; }
        public DeliveryStatus status { get; set; }
        public DeliveryProgressModel progress { get; set; }
        public AddressModel deliveryPartnerUnitAddress { get; set; }
        public List<OrderResponseModel> orders;
        public List<DeliveryLocationResponse> deliveryLocations { get; set; }

        public static DeliveryWithOrdersResponse FromDelivery(Delivery delivery)
        {
            AddressModel deliPartnerAddress = Mapper.Map<AddressModel>
             (
                 delivery.DeliveryLocation
                 .Where(location => location.locationType == LocationType.DeliveryPartner)
                 .First().address
             );
            return new DeliveryWithOrdersResponse
            {
                id = delivery.id,
                status = delivery.status,
                progress = Mapper.Map<DeliveryProgressModel>(delivery.deliveryDriver),
                deliveryPartnerUnitAddress = deliPartnerAddress,
                orders = delivery.OrderDelivery
                    .Select(orderDeli => Mapper.Map<OrderResponseModel>(orderDeli.order))
                    .ToList(),
                deliveryLocations = delivery.DeliveryLocation
                    .Select(deliLocation => Mapper.Map<DeliveryLocationResponse>(deliLocation))
                    .ToList(),
            };

        }

    }
}
