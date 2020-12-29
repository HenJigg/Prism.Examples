using Prism.Mvvm;

namespace Prism.Navigation.ViewModels
{
    public class TwoViewModel : BindableBase
    {
        private string title = "TwoView";

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }
    }
}
