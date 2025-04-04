using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace SmartHouseApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "Smart House";
        [ObservableProperty]
        private string _description = "Welcome to the Smart House App!";
        [ObservableProperty]
        private string _temperature = "22°C";
        [ObservableProperty]
        private string _humidity = "45%";
        [ObservableProperty]
        private string _lightStatus = "Off";
        [ObservableProperty]
        private string _doorStatus = "Closed";
        public MainViewModel()
        {
            // Initialize properties or load data here if needed
        }

        [RelayCommand]
        async Task GoToConnectPage()
        {
            // Navigate to the ConnectPage
            await Shell.Current.GoToAsync($"{nameof(ConnectPage)}?BaseIp=192.168.1");

        }

    }

}
