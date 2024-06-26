﻿using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class TemplateModel: BaseModel<Template, TemplateModel>
    {
        [JsonIgnore]
        override public int id { get; set; }

        public List<PropertyValuesModel> templateProperties { get; set; }
    }
}
