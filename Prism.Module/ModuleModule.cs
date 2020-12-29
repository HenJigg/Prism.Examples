using Prism.Ioc;
using Prism.Modularity;
using Prism.Module.Views;
using Prism.Regions;

namespace Prism.Module
{
    public class ModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModuleView>();
        }
    }
}