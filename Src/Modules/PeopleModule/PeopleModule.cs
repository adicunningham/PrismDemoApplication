using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PeopleModule.ViewModel;
using PeopleModule.Views;
using PrimsDemoApplication.Infrastructure;

namespace PeopleModule
{
    public class PeopleModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public PeopleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            IRegion region = _regionManager.Regions[RegionNames.ContentRegion];
            
            var vm = _container.Resolve<IPersonViewModel>();
            vm.CreatePerson("Adrian", "Cunningham");

            region.Add(vm.View);
            region.Activate(vm.View);


            var vm2 = _container.Resolve<IPersonViewModel>();
            vm2.CreatePerson("Victoria", "Cunningham");
            region.Add(vm2.View);

            var vm3 = _container.Resolve<IPersonViewModel>();
            vm3.CreatePerson("Patrick", "Dill");
            region.Add(vm3.View);
        }

        public void RegisterViewsAndServices()
        {
            _container.RegisterType<IPersonViewModel, PersonViewModel>();
            _container.RegisterType<IPersonView, PersonView>();
        }
    }
}
