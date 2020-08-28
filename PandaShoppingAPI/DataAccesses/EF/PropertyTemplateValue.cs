﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class PropertyTemplateValue
    {
        [Key]
        public int id { get; set; }
        public int propertyTemplateId { get; set; }
        [Required]
        [StringLength(500)]
        public string value { get; set; }

        [ForeignKey(nameof(propertyTemplateId))]
        [InverseProperty(nameof(PropertyTemplate.PropertyTemplateValue))]
        public virtual PropertyTemplate propertyTemplate { get; set; }
    }
}