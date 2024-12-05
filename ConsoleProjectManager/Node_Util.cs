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
            string[] options = { "Express Js","Typescript" };
            int chosenIndex = Util.ShowOptions(options, "Choose the boilerplate you want");
            switch (chosenIndex)
            {
                case 0: Express(); break;
                case 1: Typescript(); break;
            }
        }

        static void Express()
        {
            string? name = Util.FileName("Enter the file name");

            string buildsPath = Path.Combine(Directory.GetCurrentDirectory(), "builds");
            Directory.CreateDirectory(buildsPath);

            string directoryPath = Path.Combine(buildsPath, name);
            Directory.CreateDirectory(directoryPath);

            Util.ExecuteCommand("npm init -y", directoryPath);
            Util.ExecuteCommand("npm i express", directoryPath);

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

            File.WriteAllText(Path.Combine(routesPath, "route.js"), routerContents);
            File.WriteAllText(Path.Combine(middlewaresPath, "auth.js"), "");

        }

        static void Typescript()
        {
            string? name = Util.FileName("Enter the file name");

            string buildsPath = Path.Combine(Directory.GetCurrentDirectory(), "builds");
            Directory.CreateDirectory(buildsPath);

            string directoryPath = Path.Combine(buildsPath, name);
            Directory.CreateDirectory(directoryPath);

            Util.ExecuteCommand("npm install typescript express", directoryPath);
            Util.ExecuteCommand("npm install ts-node @types/express --save-dev", directoryPath);

            string src = Path.Combine(directoryPath, "src");
            Directory.CreateDirectory(src);

            int port = 8080;
            // index.ts
            string indexContents = $@"import express from ""express"";
import router from ""./routes/route"";
const app = express();
const port = {port};

app.use(express.json());
app.get(""/api"",router);

app.listen(port);
";

            File.WriteAllText(Path.Combine(src, "index.ts"), indexContents);
            string routesPath = Path.Combine(src, "routes");
            Directory.CreateDirectory(routesPath);
            string middlewaresPath = Path.Combine(src, "middlewares");
            Directory.CreateDirectory(middlewaresPath);

            string routerContents = @"import express from ""express"";

const router = express.Router();
export default router;
";

            File.WriteAllText(Path.Combine(routesPath,"route.ts"), routerContents);
            File.WriteAllText(Path.Combine(middlewaresPath, "auth.ts"), "");
        }

    }
}

