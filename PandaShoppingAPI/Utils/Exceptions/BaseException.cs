using System;

namespace PandaShoppingAPI.Utils.Exceptions
{
    public class BaseException: Exception
    {
        public BaseException(ErrorCode errorCode, string message = ""): base(message)
        {
            this.errorCode = errorCode;
        }

        public ErrorCode errorCode { get; set; }

    }
}
