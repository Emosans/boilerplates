using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectManager
{
    internal static class Go_Util
    {
        public static void Go()
        {
            string? name = Util.FileName("Enter the file name");

            string buildsPath = Path.Combine(Directory.GetCurrentDirectory(), "builds");
            Directory.CreateDirectory(buildsPath);

            string directoryPath = Path.Combine(buildsPath, name);
            Directory.CreateDirectory(directoryPath);

            Util.ExecuteCommand($"go mod init {name}", directoryPath);

            string mainContents = @"package main

import (
""fmt""
)

func main(){
    fmt.Println(""hello world"");
}";

            File.WriteAllText(Path.Combine(directoryPath,"main.go"),mainContents);
        }
    }
}
