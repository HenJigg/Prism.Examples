using Prism.Mvvm;
using Prism.Regions;

namespace Prism.Navigation.ViewModels
{
    public class OneViewModel : BindableBase, INavigationAware
    {
        private string title = "OneView";

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        private string navigationParameter = string.Empty;

        public string NavigationParameter
        {
            get { return navigationParameter; }
            set { navigationParameter = value; RaisePropertyChanged(); }
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters.GetValue<string>("Value");

            if (NavigationParameter.Equals(param))
                return true;
            else
                return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Value"))
                NavigationParameter = navigationContext.Parameters.GetValue<string>("Value");
        }
    }
}
