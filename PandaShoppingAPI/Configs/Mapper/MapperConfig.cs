using AutoMapper;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Configs
{
    public static class MapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(config =>
            {
                config.AddMapperProfiles(Assembly.GetEntryAssembly());
            });

            //Compile mapping after configuration to boost map speed
            Mapper.Configuration.CompileMappings();
        }

        //public static void AddMappingProfiles(this IMapperConfigurationExpression config)
        //{
        //    config.AddMappingProfiles(Assembly.GetEntryAssembly());
        //}

        public static void AddMapperProfiles(
            this IMapperConfigurationExpression config,
            params Assembly[] assemblies)
        {
            var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

            var mappingProfileImpls = allTypes
                .Where(
                    type => type.IsClass && !type.IsAbstract &&
                    type.GetInterfaces().Contains(typeof(IMapperProfile)))
                .Select(type => (IMapperProfile)Activator.CreateInstance(type));

            var profile = new CompositeMapperProfile(mappingProfileImpls);

            config.AddProfile(profile);
        }
    }
}
