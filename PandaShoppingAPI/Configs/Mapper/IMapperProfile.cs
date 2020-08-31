using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace PandaShoppingAPI.Configs
{
    public interface IMapperProfile
    {
        void CreateMappings(Profile profile,
            IConfiguration config);
    }
}