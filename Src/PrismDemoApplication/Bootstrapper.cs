﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
//using Module;
using PrimsDemoApplication.Infrastructure;

namespace PrismDemoApplication
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window) Shell;
            App.Current.MainWindow.Show();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    ModuleCatalog catalog = new ModuleCatalog();
        //    catalog.AddModule(typeof (ModuleAModule));
        //    return catalog;
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // Configure Module Catalog via directory.
            //return new DirectoryModuleCatalog() {ModulePath = @".\Modules"};

            // Configure Module Catalog from Xaml
            //return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri("/PrismDemoApplication;component/Resources/XamlCatalog.xaml", UriKind.Relative));
        
            return new ConfigurationModuleCatalog();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof (StackPanel), Container.Resolve <StackPanelRegionAdapter>());
            return mappings;
        }
    }
}
