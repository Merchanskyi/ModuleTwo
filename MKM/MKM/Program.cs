using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MKM
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            Console.Write("Введите название файла: ");
            string find = Console.ReadLine();

            var files = Search(@"C:\", find);

            foreach (var file in files)
            {
                Process.Start("notepad.exe", file);
            }

            Console.WriteLine(files);
            Console.ReadKey();
        }

        private static List<string> Search(string baseDirectory, string filename)
        {
            var files = new List<string>();

            if (!Directory.Exists(baseDirectory))
            {
                return files;
            }

            try
            {
                Console.WriteLine(baseDirectory);
                files.AddRange(Directory.GetFiles(baseDirectory).Where(x => Path.GetFileName(x).ToLower() == filename.ToLower()));

                if (files.Any())
                {
                    return files;
                }

                var direcotires = Directory.GetDirectories(baseDirectory);

                foreach (var directory in direcotires)
                {
                    files.AddRange(Search(directory, filename));

                    if (files.Any())
                    {
                        return files;
                    }
                }
            }
            catch { }

            return files;
        }
    }
}
