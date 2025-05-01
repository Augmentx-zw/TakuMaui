namespace TakuMaui.Pages;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
        NavigateToMainPage();
    }

    private async void NavigateToMainPage()
    {
        // Show splash screen for 2 seconds
        await Task.Delay(2000);
        await Shell.Current.GoToAsync("//MainPage");
    }
}