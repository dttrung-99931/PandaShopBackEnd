﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductPropertyValue
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(500)]
        public string value { get; set; }
        public int productId { get; set; }
        public int propertyId { get; set; }

        [ForeignKey(nameof(productId))]
        [InverseProperty(nameof(Product.ProductPropertyValue))]
        public virtual Product product { get; set; }
        [ForeignKey(nameof(propertyId))]
        [InverseProperty(nameof(Property.ProductPropertyValue))]
        public virtual Property property { get; set; }
    }
}