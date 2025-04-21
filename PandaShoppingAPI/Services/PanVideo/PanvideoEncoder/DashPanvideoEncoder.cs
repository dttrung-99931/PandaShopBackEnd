using System.IO;

namespace PandaShoppingAPI.Services 
{
    public class DashPanvideoEncoder : BasePanvideoEncoder, IPanvideoEncoder
    {
        public DashPanvideoEncoder(){}
        public bool Encode(string inputVideoPath, string outputVideoDir, string outputVideoName)
        {
            return EncodeDASH(inputVideoPath, outputVideoDir, outputVideoName, 2);
        }

        // Encode video to DASH
        protected bool EncodeDASH(string inputVideoPath, string outputVideoDir, string outputVideoName, int segDuration)
        {
            string dashDir = $"{outputVideoDir}/{outputVideoName}/dash";
            if (Directory.Exists(dashDir))
            {
                // DASH was covnerted before 
                return true;
            } 

            Directory.CreateDirectory(dashDir);
            string dashFileName = $"{dashDir}/video.mpd";
            string args =
                $"-i \"{inputVideoPath}\" -c:v libx264 -b:v 3500k -preset fast " +
                "-c:a aac -b:a 128k " +
                $"-f dash -seg_duration {segDuration} \"{dashFileName}\"";
            return RunFFMPEG(args);
        }


        // Encode video to DASH, use multiuple segement duration for fast playing video 
        // For first 3s of video, segment duration = 1s
        // For the remaining of video, segment duration = 2s
        public bool EncodeMultiSegmentDuration(string inputVideoPath, string outputVideoDir, string outputVideoName)
        {
            string hlsDir = $"{outputVideoDir}/{outputVideoName}/dash";
            if (Directory.Exists(hlsDir))
            {
                // DASH was covnerted before 
                return true;
            } 

            Directory.CreateDirectory(hlsDir);
            
            // Split input video into first3s video and remaning video
            string first3sVideoPath = $"{hlsDir}/first-3s.mp4";
            TrimDashVideo(inputVideoPath, first3sVideoPath, 0, 3);

            string remainingVideoPath = $"{hlsDir}/remaning.mp4";
            TrimDashVideo(inputVideoPath, remainingVideoPath, 3);

            // Fragment video 
            string first3sFragVideoPath = $"{hlsDir}/first-3s-frag.mp4";
            FragmentVideo(first3sVideoPath, first3sFragVideoPath, 1);            

            string remainingFragVideoPath = $"{hlsDir}/remaning-frag.mp4";
            FragmentVideo(remainingVideoPath, remainingFragVideoPath, 2);            

            // Convert fragment videos to dash and merged into one
            string mp4DashArgs = $"--output-dir={hlsDir} --force --use-segment-timeline {first3sFragVideoPath} {remainingFragVideoPath} --mpd-name video.mpd";

            return RunMp4Dash(mp4DashArgs);
            // if (RunMp4Dash(mp4DashArgs))
            // {
            //     // Rename output file to .../video.mpd
            //     return Run("mv", $"{hlsDir}/stream.mpd {hlsDir}/video.mpd");
            // }
            // return false;
        }

        protected bool TrimDashVideo(string inputVideoPath, string outputPath, int startSec, int? durationInSecs = null)
        {
            ValidateFileExist(inputVideoPath);
            string startArg =  $"-ss {startSec}";
            string durationArg = durationInSecs != null ? $"-t {durationInSecs}" : "";
            // Add these args for fixing vidoe not aligned error, but it may reduce video quality 
            string ignoreAlignedError = "-keyint_min 48 -sc_threshold 0"; 
            string encodeArgs = $"-c:v libx264 -b:v 2000k -preset fast -c:a aac -b:a 128k {ignoreAlignedError}";

            string trimArgs = $"-i {inputVideoPath} {startArg} {durationArg} {encodeArgs} {outputPath}";
            return RunFFMPEG(trimArgs);
        }


    }
}