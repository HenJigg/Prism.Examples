using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
