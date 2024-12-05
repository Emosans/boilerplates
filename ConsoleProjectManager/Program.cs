using System.Diagnostics;

namespace ConsoleProjectManager
{
    class Program
    {
        static void Main()
        {
            string[] options = { "C File", "Node" , "Rust", "Golang" };
            int chosenIndex = Util.ShowOptions(options, "Choose a setup");

            switch (chosenIndex)
            {
                case 0: CFiles_Util.CFile(); break;
                case 1: Node_Util.Node(); break;
                case 2: Rust_Util.Rust(); break;
                case 3: Go_Util.Go(); break;
            }
        }
    }
}