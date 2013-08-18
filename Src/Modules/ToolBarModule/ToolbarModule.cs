using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrimsDemoApplication.Infrastructure;
using ToolBarModule.ViewModels;
using ToolBarModule.Views;

namespace ToolBarModule
{
    public class ToolbarModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;


        public ToolbarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            var vm = _container.Resolve<IToolbarViewModel>();
            _regionManager.Regions[RegionNames.ToolbarRegion].Add(vm.View);

        }

        private void RegisterViewsAndServices()
        {
            _container.RegisterType<IToolbarViewModel, ToolbarViewModel>();
            _container.RegisterType<IToolbarView, ToolBarView>();
        }

        
    }
}
