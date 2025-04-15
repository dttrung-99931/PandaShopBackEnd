
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public class PanVideoResposne : BaseModel<PanVideo, PanVideoResposne>
    {
        public string title { get; set; }
        public string description { get; set; }
        public string videoUrl { get; set; }
        public string thumbImageUrl { get; set; }
        public int durationInSecs { get; set; }


        protected override void CustomMapping(
            IMappingExpression<PanVideo, PanVideoResposne> mappingExpression,
            IConfiguration config)
        {
            mappingExpression.ForMember
            (
                panvideoRes => panvideoRes.videoUrl,
                option => option.MapFrom(
                    panvideo =>  Path.Combine(
                            config["Path:PanVideoEndPoint"], 
                            panvideo.fileName
                        ) 
                )
            )
            .ForMember
            (
               panvideoRes => panvideoRes.thumbImageUrl,
                option => option.MapFrom(
                    panvideo =>  Path.Combine(
                            config["Path:PanVideoThumbImageEndPoint"], 
                            panvideo.thumbImageFileName
                        ) 
                )
            );
        }
    }
}