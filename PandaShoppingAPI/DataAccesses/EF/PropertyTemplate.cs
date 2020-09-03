﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class PropertyTemplate
    {
        public PropertyTemplate()
        {
            PropertyTemplateValue = new HashSet<PropertyTemplateValue>();
        }

        [Key]
        public int id { get; set; }
        public int templateId { get; set; }
        public int propertyId { get; set; }
        public bool? isRequired { get; set; }

        [ForeignKey(nameof(propertyId))]
        [InverseProperty(nameof(Property.PropertyTemplate))]
        public virtual Property property { get; set; }
        [ForeignKey(nameof(templateId))]
        [InverseProperty(nameof(Template.PropertyTemplate))]
        public virtual Template template { get; set; }
        [InverseProperty("propertyTemplate")]
        public virtual ICollection<PropertyTemplateValue> PropertyTemplateValue { get; set; }
    }
}