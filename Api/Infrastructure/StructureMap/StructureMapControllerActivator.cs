using StructureMap;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Api.Infrastructure.StructureMap
{
    public class StructureMapControllerActivator : IHttpControllerActivator
    {
        private IContainer _container;

        public StructureMapControllerActivator(IContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var nestedContainer = _container.GetNestedContainer();
            var instance = nestedContainer.GetInstance(controllerType) as IHttpController;

            request.RegisterForDispose(nestedContainer);

            return instance;
        }
    }
}