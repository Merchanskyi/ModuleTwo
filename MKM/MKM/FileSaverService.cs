using System;
using System.IO;

namespace MKM
{
    public interface IFileSaverService
    {
        bool SaveFile(string content, string location, string fileName);
    }

    public class FileSaverService : IFileSaverService
    {
        ///<summary> Save a new text to the existed file and rename it adding '_reverse' to the file name. </summary>
        ///<param name ="content" type = string> Text that will be saved to the file. </param>
        ///<param name ="location" type = string> Full path to the file (e.g. 'D:\folder\name.txt'). </param>
        ///<param name ="fileName" type = string> File name (e.g. 'name.txt'). </param>
        public bool SaveFile(string content, string location, string fileName)
        {
            bool result = false;

            try
            {
                string newFileName = fileName.Replace(".txt", "_reverse.txt");

                string newLocation = Path.Combine(Path.GetDirectoryName(location), newFileName);

                File.Move(location, newLocation);
                File.WriteAllText(newLocation, content);

                result = true;
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File with pointed location " + location + " cannot be found.");
                Console.ResetColor();
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It's impossible to create the file with such name, it has already existed. Or source file name was not found. ");
                Console.ResetColor();
            }

            return result;
        }
    }
}
