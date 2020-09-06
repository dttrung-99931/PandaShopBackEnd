using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string message) : base(message)
        {
        }

        public static ConflictException Forbidden(string action, string objectName, int id)
        {
            return new ConflictException
            (
                string.Format("{0} is forbidden on {1} id {2}", action, objectName, id)
            );
        }

        public ConflictException(string action, string objectName, int id) : 
         
            this(string.Format("{0} is conflicted on {1} id {2}", action, objectName, id))
        {
        }

        protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
