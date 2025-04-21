using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;

namespace PandaShoppingAPI.Services 
{
    class FFmpegException : BaseException
    {
        public FFmpegException(string message) : base(ErrorCode.ffmpegVideoEncoding, message)
        {
        }
    }
}