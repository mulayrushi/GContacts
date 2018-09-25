using GContacts.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand SearchTextChangedCommand { get; set; }
        public ICommand AccountCommand { get; set; }
        public ICommand AddContactCommand { get; set; }
        public ICommand LabelCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand SendFeedbackCommand { get; set; }
        public ICommand HelpCommand { get; set; }

        public ICommand SignOutCommand { get; set; }

        //public ObservableCollection<ViewModels.Contact> Persons { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
