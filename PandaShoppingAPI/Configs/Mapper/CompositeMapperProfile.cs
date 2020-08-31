using AutoMapper;
using PandaShoppingAPI.Models.Base;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;
using Microsoft.Extensions.Configuration;

namespace PandaShoppingAPI.Configs
{
    internal class CompositeMapperProfile: Profile
    {
        public CompositeMapperProfile(IEnumerable<IMapperProfile> mappings,
            IConfiguration config)
        {
            foreach (var mapping in mappings)
                mapping.CreateMappings(this, config);
        }
    }
}