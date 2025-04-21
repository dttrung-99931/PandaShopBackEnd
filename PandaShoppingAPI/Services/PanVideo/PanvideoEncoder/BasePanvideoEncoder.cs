using System;
using System.Diagnostics;
using System.IO;
using PandaShoppingAPI.Utils.Exceptions;

namespace PandaShoppingAPI.Services 
{
    public class BasePanvideoEncoder: CmdRunner
    {

        protected bool TrimVideo(string inputVideoPath, string outputPath, int startSec, int? durationInSecs = null)
        {
            ValidateFileExist(inputVideoPath);
            string startArg =  $"-ss {startSec}";
            string durationArg = durationInSecs != null ? $"-t {durationInSecs}" : "";
            string trimArgs = $"{startArg} {durationArg} -i {inputVideoPath} -c copy {outputPath}";
            return RunFFMPEG(trimArgs);
        }

        protected bool FragmentVideo(string inputVideoPath, string outputPath, int durationInSecs) 
        {
            ValidateFileExist(inputVideoPath);
            string args = $"--fragment-duration {1000*durationInSecs} {inputVideoPath} {outputPath}";
            return RunMp4Fragment(args);
        }
   }
}