using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using PrimsDemoApplication.Infrastructure;

namespace ServiceModule
{
    public class ServiceModule : IModule
    {
        private IUnityContainer _container;

        public ServiceModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            // Registers the service as a singleton
            _container.RegisterType<IPersonRepository, PersonRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
