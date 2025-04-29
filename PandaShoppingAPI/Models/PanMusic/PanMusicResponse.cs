
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public class PanMusicResposne : BaseModel<PanMusic, PanMusicResposne>
    {
        public string title { get; set; }
        public string musicUrl { get; set; }
        public int durationInSecs { get; set; }


        protected override void CustomMapping(
            IMappingExpression<PanMusic, PanMusicResposne> mappingExpression,
            IConfiguration config)
        {
            mappingExpression.ForMember
            (
                panMusicRes => panMusicRes.musicUrl,
                option => option.MapFrom(
                    panMusic => Path.Combine(
                            config["Path:PanMusicEndPoint"],
                            panMusic.fileName
                        )
                )
            )
           ;
        }
    }
}