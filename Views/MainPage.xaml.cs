using CursValutarApp.Models;

namespace CursValutarApp.Views;

public partial class MainPage : ContentPage
{

    List<Curs> listaCurs;//= new List<Curs>();
    public MainPage()
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {

        listaCurs = await Helpers.Net.GetAllRates();
        listViewCurs.ItemsSource = listaCurs;
        base.OnAppearing();
    }

    private void ToolbarItemConvertor_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ConvertorPage());
    }
    private void ToolbarItemIstoric_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new IstoricPage());
    }
    private void ToolbarItemSetari_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SetariPage());
    }
    private void ToolbarItemDespre_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DesprePage());
    }

}

