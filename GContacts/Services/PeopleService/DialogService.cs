using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace GContacts.Services
{
    public class DialogService
    {
        public async void ShowDialog(string message, string title)
        {
            MessageDialog messageDialog = new MessageDialog(message,title);
            await messageDialog.ShowAsync();
        }


    }
}
