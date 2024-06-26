﻿using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class InvoiceRepo : BaseRepo<Invoice>, IInvoiceRepo
    {
        public InvoiceRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
