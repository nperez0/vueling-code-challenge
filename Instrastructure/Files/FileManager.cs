using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Instrastructure.Files
{
    public class FileManager : IFileManager
    {
        IPathResolver _pathResolver;

        public FileManager(IPathResolver pathResolver)
        {
            _pathResolver = pathResolver;
        }

        public IEnumerable<T> Read<T>(string fileName)
        {
            var filePath = Path.Combine(_pathResolver.GetPath("/Files"), fileName);

            if (File.Exists(filePath))
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    return (List<T>)serializer.Deserialize(file, typeof(List<T>));
                }
            }

            return Enumerable.Empty<T>();
        }

        public void Write<T>(IEnumerable<T> data, string fileName)
        {
            var basePath = _pathResolver.GetPath("/Files");
            var filePath = Path.Combine(basePath, fileName);

            EnsurePathExist(basePath);

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }

        private void EnsurePathExist(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
