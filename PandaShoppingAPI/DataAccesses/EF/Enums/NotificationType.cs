using System;
namespace PandaShoppingAPI.DataAccesses.EF
{
	public enum NotificationType
	{
        UserOrderNoti = 1, 
        ShopOrderNoti = 2, 
        Ads = 4, // ...
        DriverTakeDelivery = 8,
    }
}

