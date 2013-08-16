using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ModuleA;
using PrimsDemoApplication.Infrastructure;

namespace Module
{
    public class ModuleAModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];

            region.Add(_container.Resolve(typeof (ToolbarView)));

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof (ContentView));
        }
    }
}
