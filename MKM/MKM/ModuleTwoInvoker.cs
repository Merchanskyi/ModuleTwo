using System;
using System.Collections.Generic;

namespace MKM
{
    public class ModuleTwoInvoker : IModuleTwoInvoker
    {
        public ModuleTwoInvoker()
        {
            _finderService = new FinderService();
            _fileReaderService = new FileReaderService();
            _fileSaverService = new FileSaverService();
        }

        private IFinderService _finderService { get; }
        private IFileReaderService _fileReaderService { get; }
        private IFileSaverService _fileSaverService { get; }

        public List<string> FindFile(string baseDirectory, string fileName)
        {
            var files = new List<string>();

            try
            {
                files = _finderService.FindFile(baseDirectory, fileName);
            }
            catch { }

            return files;
        }

        public string GetFileContent(string location, string fileName)
        {
            var result = string.Empty;

            try
            {
                result = _fileReaderService.GetFileContent(location, fileName);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong" + e.Message);
                Console.ResetColor();
            }

            return result;
        }

        public bool SaveFile(string content, string location, string fileName)
        {
            var result = false;

            try
            {
                result = _fileSaverService.SaveFile(content, location, fileName);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while saving the file. Error: " + e.Message);
                Console.ResetColor();
            }

            return result;
        }
    }
}
