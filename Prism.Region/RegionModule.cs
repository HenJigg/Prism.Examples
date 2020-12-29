using Prism.Ioc;
using Prism.Modularity;
using Prism.Region.Views;
using Prism.Regions;

namespace Prism.Region
{
    public class RegionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RegionView>();
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}