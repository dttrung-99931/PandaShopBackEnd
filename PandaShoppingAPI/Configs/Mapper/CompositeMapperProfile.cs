using AutoMapper;
using PandaShoppingAPI.Models.Base;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

namespace PandaShoppingAPI.Configs
{
    internal class CompositeMapperProfile: Profile
    {
        public CompositeMapperProfile(IEnumerable<IMapperProfile> mappings)
        {
            foreach (var mapping in mappings)
                mapping.CreateMappings(this);
        }
    }
}