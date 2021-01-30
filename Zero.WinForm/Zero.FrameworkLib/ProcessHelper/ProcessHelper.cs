using System;
using System.Diagnostics;
using System.IO;

namespace Zero.FrameworkLib.ProcessHelper
{

    public class ProcessHelper
    {
        /// <summary>
        /// 5.26新加，返回执行命令是否成功，如果失败还返回错误字符串
        /// </summary>
        /// <param name="optionalFilePath"></param>
        /// <param name="errorStr"></param>
        /// <returns></returns>
        public static bool ExecuteCmd(string optionalFilePath, out string errorStr)
        {
            Process process = new Process
            {
                StartInfo = { FileName = "cmd.exe", WindowStyle = ProcessWindowStyle.Hidden, UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, RedirectStandardError = true, Verb = "runas", CreateNoWindow = true },
                EnableRaisingEvents = true
            };
            process.Start();
            process.StandardInput.WriteLine(optionalFilePath);
            process.StandardInput.WriteLine("exit");
            string result = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            process.Close();
            if (string.IsNullOrEmpty(error))
            {
                errorStr = "";
                return true;
            }
            else
            {
                errorStr = error;
                return false;
            }
        }

        public static string ExecuteCmd(string optionalFilePath)
        {
            int exitCode;
            return ExecuteCmd(optionalFilePath, out exitCode);
        }

        public static string ExecuteCmd(string optionalFilePath,out int exitCode)
        {
            Process process = new Process
            {
                StartInfo = { FileName = "cmd.exe", WindowStyle = ProcessWindowStyle.Hidden, UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, RedirectStandardError = true, Verb = "runas", CreateNoWindow = true },
                EnableRaisingEvents = true
            };
            process.Start();
            process.StandardInput.WriteLine(optionalFilePath);
            process.StandardInput.WriteLine("exit");
            string str = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            exitCode = process.ExitCode;
            process.Close();
            return str;
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
            w.Flush();
        }

        public static Result RunExternalExe(string filename, string arguments = "")
        {
            Result result = new Result
            {
                IsOk = true
            };
            Process process = new Process
            {
                StartInfo = { FileName = filename, Arguments = arguments, WindowStyle = ProcessWindowStyle.Hidden, UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, RedirectStandardError = true, Verb = "runas", CreateNoWindow = true },
                EnableRaisingEvents = true
            };
            Action<object, DataReceivedEventArgs> actionWrite = delegate(object sender, DataReceivedEventArgs e)
            {
                result.Message = result.Message + e.Data;
            };
            process.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
            {
                actionWrite(sender, e);
            };
            process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
            {
                actionWrite(sender, e);
            };
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            result.Code = process.ExitCode.ToString();
            if ((process.ExitCode != 0) && (process.ExitCode != 0xbc2))
            {
                result.IsOk = false;
            }
            return result;
        }
    }

    public class Result
    {
        public string Code { get; set; }

        public bool IsOk { get; set; }

        public string Message { get; set; }
    }
}
