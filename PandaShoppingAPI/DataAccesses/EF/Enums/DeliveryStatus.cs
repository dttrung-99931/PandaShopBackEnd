using System;
namespace PandaShoppingAPI.DataAccesses.EF
{
	public enum DeliveryStatus
	{
        Created = 1, // when an order.status = Created
        FindingDriver = 4, 
        FoundDriver = 6, // When a driver found & driver confirm 
        MovingToShop = 8, 
        ReceivingProduct = 12, // Driver come to the shop and waiting for receiving the product
        Delivering = 16,  // Driver has been rececived the product and moving to delivery
        Delivered = 20, // Driver delivered to buyer 
        Cancelled = 24, // 
        Lose = 28, // Lose the product
        ProductBroken = 32, // The product is broken
    }
}

