namespace TakuMaui.Pages;

public partial class ProgressBarsPage : ContentPage
{
    public ProgressBarsPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}