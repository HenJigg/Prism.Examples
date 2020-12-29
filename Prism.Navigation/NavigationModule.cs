using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Views;
using Prism.Regions;

namespace Prism.Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationView>();
        }
    }
}