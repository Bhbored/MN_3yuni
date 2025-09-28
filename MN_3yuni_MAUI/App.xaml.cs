namespace MN_3yuni_MAUI
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
            _serviceProvider = serviceProvider;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}