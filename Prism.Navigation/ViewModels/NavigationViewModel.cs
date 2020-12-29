using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Prism.Navigation.ViewModels
{
    public class NavigationViewModel : BindableBase
    {
        private string title = "Navigation";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public NavigationViewModel(IRegionManager regionManager)
        {
            NavgateCommand = new DelegateCommand(NavgatePage);
            NavgateParaCommand = new DelegateCommand<string>(NavgatePage);
            this.regionManager = regionManager;
        }

        private readonly IRegionManager regionManager;

        public DelegateCommand NavgateCommand { get; private set; }
        public DelegateCommand<string> NavgateParaCommand { get; private set; }

        /// <summary>
        /// Navigation
        /// </summary>
        void NavgatePage()
        {
            regionManager.RequestNavigate("NavigationContent", "OneView");
        }

        /// <summary>
        /// Navigation parameters
        /// </summary>
        /// <param name="parameter"></param>
        void NavgatePage(string parameter)
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("Value", parameter);

            regionManager.RequestNavigate("NavigationContent", "OneView", param);
        }
    }
}
