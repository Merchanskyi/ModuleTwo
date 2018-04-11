using System;
using System.Collections.Generic;
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
        ///<summary> Save a new text to the existed file and rename it adding '_reverse' to the file name. </summary>
        ///<param name ="baseDirectory" type = string> baseDirectory. </param>
        ///<param name ="fileName" type = string> File name (e.g. 'name.txt'). </param>
        public List<string> FindFile(string baseDirectory, string fileName)
        {
            var files = new List<string>();

            if (!Directory.Exists(baseDirectory))
            {
                return files;
            }

            try
            {
                Console.WriteLine(baseDirectory);

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
            catch { }

            return files;
        }
    }
}