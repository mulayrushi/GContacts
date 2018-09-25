using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GContacts.Services
{
    public class NavigationService
    {
        private Frame frame;
        public Frame Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
                frame.Navigated += OnFrameNavigated;
            }
        }

        public NavigationService()
        {

        }

        public void Navigate(Type type)
        {
            Frame.Navigate(type);
        }

        public void Navigate(Type type, object parameter)
        {
            Frame.Navigate(type, parameter);
        }
        
        public void Navigate(string type)
        {
            Frame.Navigate(Type.GetType(type));
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OnFrameNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            
        }
    }
}
