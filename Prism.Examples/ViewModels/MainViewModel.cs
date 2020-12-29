using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Prism.Examples.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            NavigationModelList = new ObservableCollection<string>();
            NavigationModelList.Add("Region");
            NavigationModelList.Add("Module");
            NavigationModelList.Add("Mvvm");
            NavigationModelList.Add("Navigation");
            NavigationModelList.Add("Dialog");

            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.regionManager = regionManager;
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public ObservableCollection<string> navigationModelList;
        private readonly IRegionManager regionManager;

        public ObservableCollection<string> NavigationModelList
        {
            get { return navigationModelList; }
            set { navigationModelList = value; RaisePropertyChanged(); }
        }


        void Execute(string NavigateName)
        {
            regionManager
                .Regions["TabControlRegion"]
                ?.RequestNavigate($"{NavigateName}View");
        }
    }
}
