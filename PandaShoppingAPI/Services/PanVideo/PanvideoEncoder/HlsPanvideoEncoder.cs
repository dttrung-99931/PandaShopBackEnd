using System.IO;

namespace PandaShoppingAPI.Services 
{
    public class HlsPanvideoEncoder : BasePanvideoEncoder, IPanvideoEncoder
    {
        public HlsPanvideoEncoder(){}
        
        public bool Encode(string inputVideoPath, string outputVideoDir, string outputVideoName)
        {
            string hlsDir = $"{outputVideoDir}/{outputVideoName}/hls";
            if (Directory.Exists(hlsDir))
            {
                // DASH was covnerted before 
                return false;
            } 
            
            Directory.CreateDirectory(hlsDir);
            string outputVideoPath = $"{hlsDir}/video.m3u8";
            string args =
                $"-i \"{inputVideoPath}\" -c:v libx264 -b:v 3500k -preset fast " +
                "-c:a aac -b:a 128k " +
                $"-f hls -hls_time 2 \"{outputVideoPath}\"";
            return RunFFMPEG(args);
        }
    }
}