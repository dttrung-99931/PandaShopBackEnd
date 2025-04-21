using System;
using System.Diagnostics;
using System.IO;
using PandaShoppingAPI.Utils.Exceptions;

namespace PandaShoppingAPI.Services 
{
    public class ThumbnailVideoService: CmdRunner 
    {

        // Take animated wepb thumb image used for video preview
        public bool GenAnimatedThumbVideoImage(string inputVideoPath, string outputThumbImgPath)
        {
            // -q:v 1 (best quality from 1 - 3)
            // string thumbnailArgs = $"ss 00:00:00 -i {inputVideoPath}  -frames:v 1 -q:v 1 {outputThumbImgPath}";
            // return RunFFMPEG(thumbnailArgs);
            // TODO:
            throw new Exception("not implemnted");
        }

        // Take wepb thumb image used for video preview
        public bool GenThumbVideoImage(string inputVideoPath, string outputThumbImgPath)
        {
            // -q:v 1 (best quality from 1 - 3)
            // -y: overridding
            string thumbnailArgs = $"-ss 00:00:00 -i {inputVideoPath}  -frames:v 1 -c:v libwebp -q:v 92  -y {outputThumbImgPath}";
            return RunFFMPEG(thumbnailArgs);
        }
   }
}