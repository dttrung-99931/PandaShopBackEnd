using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace PandaShoppingAPI.Services 
{
    public class PanvideoEncoderFactory
    {
        private readonly IServiceProvider _services;
        public PanvideoEncoderFactory(IServiceProvider services)
        {
            _services = services;
        }

        public IPanvideoEncoder GetEncoder(PanvieoEncoders type)
        {
            switch (type)
            {
                case PanvieoEncoders.hls:
                    return _services.GetService<HlsPanvideoEncoder>();
                case PanvieoEncoders.dash:
                    return _services.GetService<DashPanvideoEncoder>();
            }
            throw new Exception($"Unsupoert codec {type}");
        }
    }
}