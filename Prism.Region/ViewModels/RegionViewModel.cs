using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Prism.Region.ViewModels
{
    public class RegionViewModel : BindableBase
    {
        private string title = "Region";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private readonly IRegionManager regionManager;

        public RegionViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            ShowCommand = new DelegateCommand<string>(arg =>
            {
                //Add a view to the Region
                regionManager.Regions["RegionContent"].RequestNavigate("ViewA");
            });

            RemoveCommand = new DelegateCommand<object>(arg =>
              {
                  if (arg == null) return;
                  //Remove view from Region
                  regionManager.Regions["RegionContent"].Remove(arg);
              });
        }

        public DelegateCommand<string> ShowCommand { get; private set; }
        public DelegateCommand<object> RemoveCommand { get; private set; }
    }
}
