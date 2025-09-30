namespace MN_3yuni_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
          
            Routing.RegisterRoute(nameof(MVVM.Views.OrderDetails), typeof(MVVM.Views.OrderDetails));
        }
    }
}
