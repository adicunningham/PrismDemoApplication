using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrimsDemoApplication.Infrastructure;
using StatusBarModule.ViewModels;
using StatusBarModule.Views;

namespace StatusBarModule
{
    public class StatusBarModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public StatusBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            var vm = _container.Resolve<IStatusBarViewModel>();
            _regionManager.Regions[RegionNames.StatusBarRegion].Add(vm.View);
        }

        private void RegisterViewsAndServices()
        {
            _container.RegisterType<IStatusBarView, StatusBarView>();
            _container.RegisterType<IStatusBarViewModel, StatusBarViewModel>();
        }
    }
}
