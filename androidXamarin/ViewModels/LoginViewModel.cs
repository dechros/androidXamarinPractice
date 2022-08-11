using androidXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace androidXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command ConnectCommand { get; }

        public LoginViewModel()
        {
            ConnectCommand = new Command(OnConnectClicked);
        }

        private async void OnConnectClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private void CheckMcuConnection()
        {

        }
    }
}
