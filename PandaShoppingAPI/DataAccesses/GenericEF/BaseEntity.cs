using System;
namespace PandaShoppingAPI.DataAccesses.EF
{
    public abstract class BaseEntity
    {
        abstract public bool isDeleted { get; set; }
    }
}

