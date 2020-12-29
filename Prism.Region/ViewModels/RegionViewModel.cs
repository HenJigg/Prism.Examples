using Prism.Commands;
using Prism.Mvvm;
using Prism.Region.Views;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                  //Remove view from Region
                  regionManager.Regions["RegionContent"].Remove(arg);
              });
        }

        public DelegateCommand<string> ShowCommand { get; private set; }
        public DelegateCommand<object> RemoveCommand { get; private set; }
    }
}
