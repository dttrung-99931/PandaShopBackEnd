using System;
using System.Diagnostics;
using System.IO;

namespace PandaShoppingAPI.Services 
{
    public class BasePanvideoEncoder
    {
        protected bool RunFFMPEG(string args)
        {
            try
            {
                using var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                };
                process.Start();
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    Console.WriteLine("FFmpeg Output:\n" + process.StandardOutput.ReadToEnd());
                } 
                else 
                {
                    Console.WriteLine("FFmpeg exception:\n" + process.StandardError.ReadToEnd());
                }
                return process.ExitCode == 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("FFmpeg exception " + e.ToString());
                throw;
            } 
        }


    }
}