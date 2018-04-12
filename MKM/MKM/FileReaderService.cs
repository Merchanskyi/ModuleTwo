using System;
using System.IO;
using System.Security;

namespace MKM
{
    public interface IFileReaderService
    {
        string GetFileContent(string location, string fileName);
    }

    public class FileReaderService : IFileReaderService
    {
        ///<summary> Reading a text from the file and reversing content of the file. </summary>        
        ///<param name ="location" type = string> Full path to the file (e.g. 'D:\folder\name.txt'). </param>
        ///<param name ="fileName" type = string> File name (e.g. 'name.txt'). </param>        
        public string GetFileContent(string location, string fileName)
        {
            string output = string.Empty;
            string filePath = Path.Combine(location, fileName);

            try
            {
                string fileContent = File.ReadAllText(filePath);

                for (int symbol = fileContent.Length - 1; symbol >= 0; symbol--)
                {
                    output += fileContent[symbol];
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file specified in {filePath} was not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An error occurred while opening the file");
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException || ex is SecurityException)
                {
                    Console.WriteLine("The caller does not have the required permission.");
                }
                else
                {
                    throw;
                }
            }

            return output;
        }
    }
}