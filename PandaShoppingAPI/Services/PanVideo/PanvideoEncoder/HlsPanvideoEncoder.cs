using System.IO;

namespace PandaShoppingAPI.Services 
{
    public class HlsPanvideoEncoder : BasePanvideoEncoder, IPanvideoEncoder
    {
        public HlsPanvideoEncoder(){}
        
        public bool Encode(string inputVideoPath, string outputVideoDir, string outputVideoName)
        {
            string dashDir = $"{outputVideoDir}/{outputVideoName}/dash";
            if (Directory.Exists(dashDir))
            {
                // DASH was covnerted before 
                return true;
            } 
            
            Directory.CreateDirectory(dashDir);
            string outputVideoPath = $"{dashDir}/video.mpd";
            string args =
                $"-i \"{inputVideoPath}\" -c:v libx264 -b:v 2000k -preset fast " +
                "-c:a aac -b:a 128k " +
                $"-f hls -hls_time 2 \"{outputVideoPath}\"";
            return RunFFMPEG(args);
        }
    }
}