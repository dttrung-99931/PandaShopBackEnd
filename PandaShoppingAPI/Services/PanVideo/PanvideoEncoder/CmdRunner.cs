using System;
using System.Diagnostics;
using System.IO;
using PandaShoppingAPI.Utils.Exceptions;

namespace PandaShoppingAPI.Services 
{
    public class CmdRunner
    {
        protected bool RunMp4Fragment(string args)
        {
            return Run("/Users/msv/development/Bento4-SDK-1-6-0-641.universal-apple-macosx/bin/mp4fragment", args);
        }

        protected bool RunMp4Dash(string args)
        {
            return Run("/Users/msv/development/Bento4-SDK-1-6-0-641.universal-apple-macosx/bin/mp4dash", args);
        }

        protected bool RunFFMPEG(string args)
        {
            return Run("ffmpeg", args);
        }

        protected void ValidateFileExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new NotFoundException($"Not found {filePath}");
            }
        }


        protected bool Run(string processName, string args)
        {
            try
            {
                using var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = processName,
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
                    Console.WriteLine($"{processName} completed without errors");
                    return true;
                } 
                else 
                {
                    throw new Exception(process.StandardError.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                LogError(processName, args, ex);
                throw;
            } 
        }

        protected void LogError(string processName, string args, Exception ex)
        {
            Console.WriteLine($"{processName} exception. Eception message: {ex.Message}, Args = {args}, ");
        }
    }
}