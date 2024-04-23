using System;
namespace PandaShoppingAPI.DataAccesses.EF
{
	public enum PaymentStatus
	{
        PayLatter = 1,
        Pending = 4, 
        Paid = 8,
        Cancelled = 12,
        Refunded = 14,
    }
}

