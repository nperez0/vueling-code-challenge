using Api.Infrastructure.StructureMap;
using StructureMap;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Api
{
    public static class StructureMapConfig
    {
        public static IContainer Start(HttpConfiguration config)
        {
            IContainer container = new Container(_ => _.AddRegistry(new MainRegistry()));

            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapControllerActivator(container));

            return container;
        }
    }
}