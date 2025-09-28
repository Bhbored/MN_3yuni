namespace MN_3yuni_MAUI.MVVM.Views;
using Shared.Models;
using static Shared.Helpers.Enums;
using MN_3yuni_MAUI.MVVM.ViewModels;

public partial class Home : ContentPage
{
	public Home(HomeVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}


}