using Android;
using Android.Bluetooth;
using androidXamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.BLE;
using System.Threading.Tasks;

namespace androidXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command ConnectCommand { get; }

        public LoginViewModel()
        {
            ConnectCommand = new Command(OnConnectClicked);
        }

        bool connected = false;
        private async void OnConnectClicked(object obj)
        {
            CheckMcuConnectionAsync();
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void CheckMcuConnectionAsync()
        {
            var ble = CrossBluetoothLE.Current;
            var Adapter = CrossBluetoothLE.Current.Adapter;
            List<Plugin.BLE.Abstractions.Contracts.IDevice> deviceList = null;
            Adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
            await Adapter.StartScanningForDevicesAsync();
        }
    }
}
