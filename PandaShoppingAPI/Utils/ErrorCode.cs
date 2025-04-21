namespace PandaShoppingAPI.Utils
{
    public enum ErrorCode
    {
        // Common
        unknown,
        conflict,
        // User
        userExisted,
        shopExisted,
        unregisterdShop,
        notEnoughAvaialableProducts,
        deliveryWasStarted,
        driverIsNotFreeToDeliver,
        // Delivery
        deliveryNotStarted,
        // FFmpeg codes
        ffmpegVideoEncoding,

    }
}
