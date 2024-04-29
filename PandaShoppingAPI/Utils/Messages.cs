using System;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Configs.Messages
{
    public static class OrderMessages
    {
        public const string titleStatusUpdated = "Cập nhật tình trạng đơn hàng";

        public static string GetStatusMessage(this Order order)
        {
            switch (order.status)
            {
                case OrderStatus.Created:
                    return "Bạn có đơn hàng mới";
                case OrderStatus.Pending:
                    return "Bạn có đơn hàng mơi (đợi thanh toán)";
                case OrderStatus.Processing:
                    return "Người bán đang xử lý đơn hàng";
                case OrderStatus.CancelledByBuyer:
                    return "Đơn hàng bị huỷ bởi người mua!";
                case OrderStatus.CancelledByShop:
                    return "Người bán đã huỷ đơn hàng!";
                case OrderStatus.WaitingForDelivering:
                    return "Đơn hàng đã được xử lý và đang chờ vận chuyển";
                case OrderStatus.Delivering:
                    return "Đơn hàng đang được vận chuyển";
                case OrderStatus.Delivered:
                    return "Đơn hàng đã chuyển đến người mua";
                case OrderStatus.CompletedByUser:
                    return "Người mua xác nhận hoàn thành đơn hàng";
                case OrderStatus.CompletedBySystem:
                    return "ĐƠn hàng được hoàn thanh";
                case OrderStatus.Lost:
                    return "Đơn hàng thất lạc!!!";

            }
            return "";
        }
    }

}

