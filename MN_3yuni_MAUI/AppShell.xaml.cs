using MN_3yuni_MAUI.MVVM.Views;

namespace MN_3yuni_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
          
            Routing.RegisterRoute(nameof(OrderDetails), typeof(OrderDetails));
        }
    }
}
