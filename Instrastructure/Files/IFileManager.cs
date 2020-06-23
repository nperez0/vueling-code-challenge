using System.Collections.Generic;

namespace Instrastructure.Files
{
    public interface IFileManager
    {
        IEnumerable<T> Read<T>(string fileName);

        void Write<T>(IEnumerable<T> data, string fileName);
    }
}
