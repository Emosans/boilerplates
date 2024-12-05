using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectManager
{
    internal static class Util
    {
        public static int ShowOptions(string[] options,string message) {
            Console.WriteLine(message);
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) \t{options[i]}");
            }
            Console.Write("Choice ");
            int optionIndex = Convert.ToInt16(Console.ReadLine())-1;
            return optionIndex;
        }

        public static string FileName(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static void ExecuteCommand(string command, string workingDir = null)
        {
            if (string.IsNullOrEmpty(workingDir) || !Directory.Exists(workingDir))
            {
                throw new DirectoryNotFoundException($"The working directory '{workingDir}' does not exist.");
            }

            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = workingDir
            };

            using Process? process = Process.Start(processStartInfo);
            if (process == null)
            {
                throw new Exception("Failed to start process");
            }

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine(output);
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine($"Error: {error}");
            }
        }
    }
}
