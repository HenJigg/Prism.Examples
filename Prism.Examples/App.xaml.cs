using Prism.DryIoc;
using Prism.Examples.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Module;
using Prism.Mvvm;
using Prism.Mvvm.Views;
using Prism.Navigation;
using Prism.Region;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Prism.Examples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<NavigationModule>();
            moduleCatalog.AddModule<MvvmModule>();
            moduleCatalog.AddModule<ModuleModule>();
            moduleCatalog.AddModule<RegionModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
