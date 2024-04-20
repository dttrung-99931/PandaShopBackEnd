using System;
using System.ComponentModel;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public abstract class BaseEntity
    {
        [DefaultValue(false)]
        public bool isDeleted { get; set; } = false;
    }
}

