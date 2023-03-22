using CursValutarApp.Views;

namespace CursValutarApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
			//new NavigationPage(new MainPage());
	}
}
