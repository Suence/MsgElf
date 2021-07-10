using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgElf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "MsgElf";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
