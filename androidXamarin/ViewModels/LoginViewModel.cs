using Android;
using Android.Bluetooth;
using androidXamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
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
            if (CheckMcuConnection() == true)
            {
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }

        private bool CheckMcuConnection()
        {
            bool RetVal = false;
            BluetoothAdapter Adapter = BluetoothAdapter.DefaultAdapter;
            if (Adapter == null)
            {
                Application.Current.MainPage.DisplayAlert("Bluetooth Error", "Bluetooth adapter is not detected.", "OK");
            }
            else if (Adapter.IsEnabled == false)
            {
                Application.Current.MainPage.DisplayAlert("Bluetooth Error", "Bluetooth adapter is not enabled.", "OK");
            }
            else
            {
                BluetoothDevice SelectedDevice = (from BondedDevice in Adapter.BondedDevices where BondedDevice.Name.ToString().Contains("ESP") select BondedDevice).FirstOrDefault();
                if (SelectedDevice == null)
                {
                    Application.Current.MainPage.DisplayAlert("Bluetooth Error", "Pair with the MCU first.", "OK");
                }
                else
                {
                    RetVal = true;
                }
            }
            return RetVal;
        }
    }
}
