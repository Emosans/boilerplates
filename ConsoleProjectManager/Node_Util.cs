using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectManager
{
    internal static class Node_Util
    {
        public static void Node()
        {
            string[] options = { "Express Js" };
            int chosenIndex = Util.ShowOptions(options, "Choose the boilerplate you want");
            switch (chosenIndex)
            {
                case 0: Express(); break;
            }
        }

        static void Express()
        {
            string? name = Util.FileName("Enter the file name");

            string buildsPath = Path.Combine(Directory.GetCurrentDirectory(), "builds");
            Directory.CreateDirectory(buildsPath);

            string directoryPath = Path.Combine(buildsPath, name);
            Directory.CreateDirectory(directoryPath);

            ExecuteCommand("npm init -y", directoryPath);
            ExecuteCommand("npm i express", directoryPath);

            int port = 8080;

            // create index.js
            string indexContents = $@"
const express = require(""express"");
const router = require(""./routes/router"");

const app = express();
const port = {port};

app.use(express.json());
app.use(""/api"",router);
app.listen(port);
            ";


            File.WriteAllText(Path.Combine(directoryPath, "index.js"), indexContents);
            string routesPath = Path.Combine(directoryPath, "routes");
            Directory.CreateDirectory(routesPath);
            string middlewaresPath = Path.Combine(directoryPath, "middlewares");
            Directory.CreateDirectory(middlewaresPath);

            string routerContents = @"
const {Router} = require(""express"");
const router = Router();
exports.default = router;
            ";

            File.WriteAllText(Path.Combine(routesPath, "routes.js"), routerContents);
            File.WriteAllText(Path.Combine(middlewaresPath, "auth.js"), "");

        }

        static void ExecuteCommand(string command, string workingDir = null)
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

