using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MKM
{
    public interface IFinderService
    {
        List<string> FindFile(string baseDirectory, string fileName);
    }

    public class FinderService : IFinderService
    {
        public void FinderFile()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            Console.Write("Enter search disk (Example: C:\\): ");
            var dir = Console.ReadLine();

            Console.Write("Enter the name of the file(with pattern): ");
            var find = Console.ReadLine();

            var files = FindFile(@dir, find);

            foreach (var file in files)
            {
                Process.Start("notepad.exe", file);
            }

            Console.ReadKey();
        }

        public List<string> FindFile(string baseDirectory, string fileName)
        {
            var files = new List<string>();

            if (!Directory.Exists(baseDirectory))
            {
                return files;
            }

            try
            {
                Console.WriteLine(baseDirectory); // Отображать все директории в которые заходит поисковик

                files.AddRange(Directory.GetFiles(baseDirectory).Where(x => Path.GetFileName(x).ToLower() == fileName.ToLower()));

                if (files.Any())
                {
                    return files;
                }

                var direcotires = Directory.GetDirectories(baseDirectory);

                foreach (var directory in direcotires)
                {
                    files.AddRange(FindFile(directory, fileName));

                    if (files.Any())
                    {
                        return files;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Файл не найден!");
            }

            return files;
        }
    }
}