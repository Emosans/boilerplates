using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectManager
{
    internal static class CFiles_Util
    {
        public static void CFile()
        {
            string? name = Util.FileName("Enter the file name");

            string buildsPath = Path.Combine(Directory.GetCurrentDirectory(), "builds");
            Directory.CreateDirectory(buildsPath);

            string directoryPath = Path.Combine(buildsPath, name);
            Directory.CreateDirectory(directoryPath);

            string[] fileContents =
            {
                $"include {name}.h",
                $"std::string {name}::helloWorld()",
                "{",
                @"   return ""hello world!"";",
                "}"
            };

            File.WriteAllLines(Path.Combine(directoryPath, $"{name}.c"), fileContents);

            string headerDef = name.ToUpper();

            string[] headerDefines =
            {
                $"#ifndef {headerDef}",
                $"#define {headerDef}\n",
                "#include<iostream>",
                $"class {headerDef.ToLower()}",
                "{",
                "public:",
                "std::string helloWord();",
                "};",
                $"#endif // {headerDef}",
            };
            File.WriteAllLines(Path.Combine(directoryPath, $"{name}.h"), headerDefines);
        }
    }
}
