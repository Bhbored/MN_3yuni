using MN_3yuni_MAUI.MVVM.ViewModels;

namespace MN_3yuni_MAUI.MVVM.Views;


public partial class OrderPage : ContentPage
{
	private readonly ViewModels.OrderVM _orderVM;
	public OrderPage(OrderVM orderVM)
	{
		InitializeComponent();
		_orderVM = orderVM;
		BindingContext=orderVM;
	}
}