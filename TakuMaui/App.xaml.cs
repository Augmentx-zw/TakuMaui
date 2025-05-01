namespace TakuMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Shell.Current.GoToAsync("//SplashPage");
        }
    }
}
