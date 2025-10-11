using System.Windows.Input;

namespace MN_3yuni_MAUI.Controls;

public partial class FloatingTabBar : ContentView
{
    public FloatingTabBar()
    {
        InitializeComponent();
        BindingContext = this;
        NavigateCommand = new Command<string>(async route =>
        {
            if (string.IsNullOrWhiteSpace(route)) return;
            if (Shell.Current is null) return;
            await Shell.Current.GoToAsync(route);
        });
    }

    public static readonly BindableProperty NavigateCommandProperty =
        BindableProperty.Create(nameof(NavigateCommand), typeof(ICommand), typeof(FloatingTabBar));
    public ICommand NavigateCommand
    {
        get => (ICommand)GetValue(NavigateCommandProperty);
        set => SetValue(NavigateCommandProperty, value);
    }
}