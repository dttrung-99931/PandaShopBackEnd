using System;
namespace PandaShoppingAPI.DataAccesses.EF
{
	public enum LocationType
	{
        // Pcikup package from shops
        Pickup = 2, 
        // Delivery to customers
        Delivery = 4, 
        // Delivery partner location 
        DeliveryPartner = 8, 
    }
}

