using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PandaShoppingAPI.Utils.Exceptions
{
    [Serializable]
    internal class NotFoundException : KeyNotFoundException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static NotFoundException NotFound(string objectName, object id)
        {
            return new NotFoundException(objectName, id);
        }

        public static NotFoundException NotContain(
            string parentName, object parentId,
            string childName, object childId)
        {
            return new NotFoundException
                (
                    string.Format("{0} id {1} does not contains {2} id {3}",
                        parentName, parentId, childName, childId)
                ); 
        }

        public NotFoundException(string objectName, object id)
            : base(CreateNotFoundMsg(objectName, id))
        {
        }

        internal static string CreateNotFoundMsg(string objectName, object id)
        {
            return string.Format("{0} id {1} not found", objectName, id);
        }

    }
}