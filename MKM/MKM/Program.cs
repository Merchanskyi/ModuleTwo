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

            List<string> locationList = invoker.FindFile(@dir, fileName);
            
            var location = "";
            try
            {
                location = locationList[0];

                string content = invoker.GetFileContent(location, fileName);

                if (string.IsNullOrEmpty(content))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFile is empty!");
                    Console.ResetColor();
                }
                else if (invoker.SaveFile(content, location, fileName) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{fileName} file is successfully found, rewritten and renamed.");
                    Console.ResetColor();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nFile is not found!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}