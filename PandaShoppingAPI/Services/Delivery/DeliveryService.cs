using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class DeliveryService : BaseService<IDeliveryRepo, Delivery, DeliveryModel, DeliveryFilter>, 
        IDeliveryService
    {
        public DeliveryService(IDeliveryRepo repo) : base(repo)
        {
        }

        public override IQueryable<Delivery> Fill(DeliveryFilter filter)
        {
            return base.Fill(filter);
        }

        public void SetCustomerAddresses(List<DeliveryResponse> deliveries)
        {
            List<int> deliveryIds = deliveries.Select(delivery => delivery.id).ToList();
            // Dic<deliveryId, aaddress≥
            Dictionary<int, Address> customerAddresses = _repo.Where((delivery) => deliveryIds.Contains(delivery.id))
                .ToList()
                .ToDictionary(
                    delivery => delivery.id,
                    delivery => delivery.DeliveryLocation.First(location => location.locationType == LocationType.Delivery).address);
        
            // foreach (DeliveryResponse delivery in deliveries){
            //     delivery.customerAddress = Mapper.Map<AddressResponseModel>(customerAddresses[delivery.id]);
            // }
        }

        public DeliveryProgressModel GetDeliveryProgress(int deliveryId)
        {
            Delivery delivery =  GetById(deliveryId);
            if (delivery.deliveryDriver == null)
            {
                throw new ConflictException(Utils.ErrorCode.deliveryNotStarted);
            }   
            return Mapper.Map<DeliveryProgressModel>(delivery.deliveryDriver);
        }
    }
}
