using SmartHouseApp.ViewModels;

namespace SmartHouseApp
{
    public partial class ConnectPage : ContentPage
    {
        private ConnectViewModel _viewModel;

        public ConnectPage()
        {
            InitializeComponent();
            _viewModel = new ConnectViewModel();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel != null)
            {
                await _viewModel.ScanNetworkAsync("192.168.1"); // Remplacez par l'adresse IP de base de votre réseau
            }
        }
    }
}
