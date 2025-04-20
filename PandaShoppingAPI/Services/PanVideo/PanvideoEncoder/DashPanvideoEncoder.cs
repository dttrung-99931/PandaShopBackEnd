using System.IO;

namespace PandaShoppingAPI.Services 
{
    public class DashPanvideoEncoder : BasePanvideoEncoder, IPanvideoEncoder
    {
        public DashPanvideoEncoder(){}
        public bool Encode(string inputVideoPath, string outputVideoDir, string outputVideoName)
        {
            string hlsDir = $"{outputVideoDir}/{outputVideoName}/hls";
            if (Directory.Exists(hlsDir))
            {
                // DASH was covnerted before 
                return true;
            } 

            Directory.CreateDirectory(hlsDir);
            string hlsFileName = $"{hlsDir}/video.m3u8";
            string args =
                $"-i \"{inputVideoPath}\" -c:v libx264 -b:v 2000k -preset fast " +
                "-c:a aac -b:a 128k " +
                $"-f dash -seg_duration 2 \"{hlsFileName}\"";
            return RunFFMPEG(args);
        }
    }
}