using System;

namespace MKM
{
    class Program
    {
        static void Main(string[] args)
        {
            //FinderService finderService = new FinderService();

            //finderService.FinderFile();

            IModuleTwoInvoker invoker = new ModuleTwoInvoker();

            // DELETE temporary variables fileName, content and location
            string fileName = "mkm.txt";
            string content = "hi all!";
            string location = @"D:\new\mkm.txt";

            
            //string location = invoker.FindFile(@"D://", @"mkm.txt");
            //string fileName - можно регуляркой вытянуть название файла из переменной локейшн
            // string content = invoker.GetFileContent(location, fileName);

            if (invoker.SaveFile(content, location, fileName) == true)
            {
                Console.WriteLine(fileName + " file is found and renamed."); 
            }

            Console.ReadLine();

        }
    }
}