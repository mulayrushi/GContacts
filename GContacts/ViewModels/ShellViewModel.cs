using GContacts.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GContacts.ViewModels
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        private void Hamburger(object parameter)
        {
            try
            {
                var spiltView = parameter as Universal.UI.Xaml.Controls.SplitView;
                spiltView.IsPaneOpen = !spiltView.IsPaneOpen;
            }
            catch { }
        }

        public ShellViewModel()
        {
            Initialize();
        }

        private bool CommandEnabled { get { return true; } }

        private void Initialize()
        {
            try
            {
                HamburgerCommand = new DelegateCommand((parameter) => this.Hamburger(parameter), () => this.CommandEnabled);
            }
            catch { }
        }

        public ICommand HamburgerCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
