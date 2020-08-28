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
        public string errorMsg { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string errorCode { get; set; }

        public ResponseWrapper(HttpStatusCode statusCode, object data = null,
            Meta meta = null, string errorMessage = null)
        {
            this.statusCode = (int)statusCode;
            this.success = this.statusCode == 200 ||
                           this.statusCode == 201 ||
                           this.statusCode == 204;
            this.data = data;
            this.meta = meta;
            this.errorMsg = errorMessage;
        }

        public ResponseWrapper(HttpStatusCode statusCode, string errMsg) :
           this(statusCode, null, null, errMsg)
        {
        }

    }
}
