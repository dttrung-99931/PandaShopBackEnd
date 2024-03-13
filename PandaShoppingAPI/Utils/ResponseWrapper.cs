using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils
{
    [DataContract]
    public class ResponseWrapper
    {
        [DataMember]
        public bool success { get; set; }

        [DataMember]
        public int statusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Meta meta { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object data { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string errorCode { get; set; }

        public ResponseWrapper(HttpStatusCode statusCode, object data = null,
            Meta meta = null, string message = null, string errorCode = null)
        {
            this.statusCode = (int)statusCode;
            this.success = this.statusCode == 200 ||
                           this.statusCode == 201 ||
                           this.statusCode == 204;
            this.data = data;
            this.meta = meta;
            this.message = message;
            this.errorCode = errorCode;
        }

        public ResponseWrapper(HttpStatusCode statusCode, string message) :
           this(statusCode, null, null, message)
        {
        }

        public ResponseWrapper(HttpStatusCode statusCode, string message, string errorCode) :
           this(statusCode, null, null, message, errorCode)
        {
        }

    }
}
