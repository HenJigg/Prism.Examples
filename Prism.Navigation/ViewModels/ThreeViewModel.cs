using Prism.Mvvm;

namespace Prism.Navigation.ViewModels
{
    public class ThreeViewModel : BindableBase
    {
        private string title = "ThreeView";

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }
    }
}
