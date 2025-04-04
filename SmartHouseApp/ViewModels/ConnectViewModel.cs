using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SmartHouseApp.ViewModels
{
    public partial class ConnectViewModel : ObservableObject
    {
        public ConnectViewModel()
        {
            ConnectedDevices = new ObservableCollection<string>();
        }

        [ObservableProperty]
        private string _ipAddress;
        [ObservableProperty]
        private string _port;
        [ObservableProperty]
        private string _errorMessage;
        [ObservableProperty]
        private ObservableCollection<string> connectedDevices;
        [ObservableProperty]
        private string selectedDevice;

        [RelayCommand]
        public async Task ScanNetworkAsync(string baseIp)
        {
            ConnectedDevices.Clear();
            var tasks = new List<Task>();

            for (int i = 1; i < 255; i++)
            {
                string ip = $"{baseIp}.{i}";
                tasks.Add(PingDeviceAsync(ip));
            }

            await Task.WhenAll(tasks);
        }

        [RelayCommand]
        private async Task PingDeviceAsync(string ip)
        {
            Ping ping = new Ping();
            try
            {
                PingReply reply = await ping.SendPingAsync(ip, 500);
                if (reply.Status == IPStatus.Success)
                {
                    Debug.WriteLine($"Device found: {ip}");
                    ConnectedDevices.Add(ip);
                }
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
        }
    }
}
