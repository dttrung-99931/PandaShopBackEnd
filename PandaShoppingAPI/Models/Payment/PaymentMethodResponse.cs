﻿using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class PaymentMethodResponse : BaseModel<PaymentMethod, PaymentMethodResponse>
    {
        public string name { get; set; }
    }
}
