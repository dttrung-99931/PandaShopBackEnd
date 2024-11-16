using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PandaShoppingAPI.Models.Base
{
    public class JsonSerializableModel
    {
        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public Dictionary<string, object> ToDictionary()
        {
            string json = JsonConvert.SerializeObject(this);
            Dictionary<string, object> dict =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(Uri.UnescapeDataString(json));
            return dict;
        }
    }

}
