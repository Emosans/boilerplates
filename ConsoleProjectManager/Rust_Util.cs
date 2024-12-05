using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectManager
{
    internal static class Rust_Util
    {
        public static void Rust()
        {
            string[] options = { "Binary Project" };
            int chosenIndex = Util.ShowOptions(options, "Choose the boilerplate you want");

            switch (chosenIndex)
            {
                case 0: Binary_Util(); break;
            }
        }

        static void Binary_Util()
        {
            string? name = Util.FileName("Enter the folder name");

            string buildsPath = Path.Combine(Directory.GetCurrentDirectory(), "builds");
            Directory.CreateDirectory(buildsPath);

            Util.ExecuteCommand($"cargo new {name} --bin", buildsPath);
        }
    }
}
