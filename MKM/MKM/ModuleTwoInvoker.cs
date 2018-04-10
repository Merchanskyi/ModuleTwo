using System;
using System.Collections.Generic;

namespace MKM
{
    public class ModuleTwoInvoker : IModuleTwoInvoker
    {
        public ModuleTwoInvoker()
        {
            _finderService = new FinderService();
            //_fileReaderService = new FileReaderService();
            //_fileSaverService = new FileSaverService();
        }

        private IFinderService _finderService { get; }
        //private IFileReaderService _fileReaderService { get; }
        //private IFileSaverService _fileSaverService { get; }

        public List<string> FindFile(string baseDirectory, string fileName)
        {
            var result = new List<string>();

            try
            {
                result = _finderService.FindFile(baseDirectory, fileName);
            }
            catch
            {
                Console.WriteLine("Файл не найден!");
            }

            return result;
        }

        //public string GetFileContent(string location, string fileName)
        //{
        //    var result = string.Empty;

        //    try
        //    {
        //        result = _fileReaderService.GetFileContent(location, fileName);
        //    }
        //    catch (Exception e)
        //    {
        //        // your code here
        //    }

        //    return result;
        //}

        //public bool SaveFile(string content, string location, string fileName)
        //{
        //    var result = false;

        //    try
        //    {
        //        result = _fileSaverService.SaveFile(content, location, fileName);
        //    }
        //    catch (Exception e)
        //    {
        //        // your code here
        //    }

        //    return result;
        //}
    }
}
