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

namespace ModuleA
{
    //[Module(ModuleName = "ModuleA", OnDemand = true)]
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
            //IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];

            //region.Add(_container.Resolve(typeof (ToolbarView)));

            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof (ContentView));

            _container.RegisterType<ToolbarView>();
            _container.RegisterType<ContentView>();
            _container.RegisterType<IContentViewViewModel, ContentViewViewModel>();
        }
    }
}
