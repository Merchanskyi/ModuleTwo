using System.Collections.Generic;

namespace MKM
{
    public interface IModuleTwoInvoker
    {
        List<string> FindFile(string baseDirectory, string fileName);

        //string GetFileContent(string location, string fileName);

        //bool SaveFile(string content, string lcoation, string fileName);
    }
}
