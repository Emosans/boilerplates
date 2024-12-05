namespace ConsoleProjectManager
{
    class Program
    {
        static void Main()
        {
            string[] options = { "C File" };
            int chosenIndex = Util.ShowOptions(options,"Choose a setup");

            switch (chosenIndex)
            {
                case 0: CFile(); break;
            }
        }

        static void CFile()
        {
            string? name = Util.FileName("Enter the file name");

            string buildsPath = Path.Combine(Directory.GetCurrentDirectory(), "builds");
            Directory.CreateDirectory(buildsPath);

            string directoryPath = Path.Combine(buildsPath, name);
            Directory.CreateDirectory(directoryPath);

            File.WriteAllText(Path.Combine(directoryPath, $"{name}.c"), $"#include \"{name}.h\"");

            string headerDef = name.ToUpper();

            string[] headerDefines =
            {
                $"#ifndef {headerDef}",
                $"#define {headerDef}\n",
                $"#endif // {headerDef}",
            };
            File.WriteAllLines(Path.Combine(directoryPath, $"{name}.h"), headerDefines);
        }
    }
}