using Instrastructure.Files;
using System.Web.Hosting;

namespace Api.Infrastructure
{
    public class PathResolver : IPathResolver
    {
        public string GetPath(string path)
        {
            return HostingEnvironment.MapPath(path);
        }
    }
}