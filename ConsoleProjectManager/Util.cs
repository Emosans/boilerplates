using System;
using System.Collections.Generic;
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
    }
}
