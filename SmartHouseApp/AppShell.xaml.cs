namespace SmartHouseApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ConnectPage), typeof(ConnectPage));
        }
    }
}
