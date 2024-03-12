using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(ErrorCode errorCode = ErrorCode.conflict, string message = "") : base(errorCode, message)
        {
        }

        public ConflictException(string action, string objectName, int id) : 
         
            this(ErrorCode.conflict, string.Format("{0} is conflicted on {1} id {2}", action, objectName, id))
        {
        }
    }
}
