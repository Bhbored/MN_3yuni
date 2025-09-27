namespace MN_3yuni_MAUI.MVVM.Views;
using Shared.Models;
using static Shared.Helpers.Enums;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        var user = new User
        {
            Id = 1,
            FirstName = "ANWARYOO 5AYOO MARIO",
        };
        text.Text = user.FirstName;
    }
  
}