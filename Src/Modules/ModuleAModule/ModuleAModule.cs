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


            _container.RegisterType<ToolbarView>();
            _container.RegisterType<IContentView, ContentView>();
            _container.RegisterType<IContentViewViewModel, ContentViewViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof (ToolbarView));

            var vm = _container.Resolve<IContentViewViewModel>();
            vm.Message = "First View";
            IRegion region = _regionManager.Regions[RegionNames.ContentRegion];
            region.Add(vm.View);

            var vm2 = _container.Resolve<IContentViewViewModel>();
            vm2.Message = "Second View";
            region = _regionManager.Regions[RegionNames.ContentRegion];

            region.Deactivate(vm.View);
            region.Add(vm2.View);
        }
    }
}
