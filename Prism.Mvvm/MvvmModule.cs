using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm.Views;
using Prism.Regions;

namespace Prism.Mvvm
{
    public class MvvmModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MvvmView>();
        }
    }
}