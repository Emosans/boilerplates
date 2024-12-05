using System.Diagnostics;

namespace ConsoleProjectManager
{
    class Program
    {
        static void Main()
        {
            string[] options = { "C File", "Node","Rust" };
            int chosenIndex = Util.ShowOptions(options, "Choose a setup");

            switch (chosenIndex)
            {
                case 0: CFiles_Util.CFile(); break;
                case 1: Node_Util.Node(); break;
                case 2: Rust_Util.Rust(); break;
            }
        }
    }
}