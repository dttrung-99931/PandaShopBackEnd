using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
