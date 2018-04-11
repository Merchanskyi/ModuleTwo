using System;
using System.Collections.Generic;
using System.IO;

namespace MKM
{
    class Program
    {
        static void Main(string[] args)
        {
            IModuleTwoInvoker invoker = new ModuleTwoInvoker();

            var currentDirectory = Directory.GetCurrentDirectory();

            Console.Write("Enter search disk (Example: C:\\): ");
            var dir = Console.ReadLine();
            Console.Write("Enter the name of the file(with pattern): ");
            var fileName = Console.ReadLine();

            List<string> location1 = invoker.FindFile(@dir, fileName);
            
            string location = "";
            try
            {
                location = location1[0];
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found!");
                Console.ResetColor();
            }

            string content = invoker.GetFileContent(location, fileName);

            if (string.IsNullOrEmpty(content))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nFile is empty");
                Console.ResetColor();
            }
            else if (invoker.SaveFile(content, location, fileName) == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{fileName} file is found and renamed.");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}