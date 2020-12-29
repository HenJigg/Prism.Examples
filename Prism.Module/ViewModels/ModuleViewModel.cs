using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ViewModels
{
    public class ModuleViewModel : BindableBase
    {
        private string title = "Module";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
