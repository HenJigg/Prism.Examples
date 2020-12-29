using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Views;

namespace Prism.Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Register Test Views
            containerRegistry.RegisterForNavigation<OneView>();
            containerRegistry.RegisterForNavigation<TwoView>();
            containerRegistry.RegisterForNavigation<ThreeView>();

            containerRegistry.RegisterForNavigation<NavigationView>();
        }
    }
}
