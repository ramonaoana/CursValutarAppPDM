using CursValutarApp.Models;

namespace CursValutarApp.Views;

public partial class ConvertorPage : ContentPage
{
	List<Curs> listaCurs=new List<Curs>();

	public ConvertorPage()
	{
		InitializeComponent();
		listaCurs.Add(new Curs()
		{
			Currency="EUR", Value=4.92, Date=DateTime.Now
		});
        listaCurs.Add(new Curs()
        {
            Currency = "USD",
            Value = 4.61,
            Date = DateTime.Now
        });
        listaCurs.Add(new Curs()
        {
            Currency = "HUF",
            Value = 1.3,
            Multiplier=100,
            Date = DateTime.Now
        });
        listaCurs.Add(new Curs()
        {
            Currency = "GBP",
            Value = 5.54,
            Date = DateTime.Now
        });
        listaCurs.Add(new Curs()
        {
            Currency = "RON",
            Value = 1,
            Date = DateTime.Now
        });

        pickerValutaSursa.ItemsSource = listaCurs;
        pickerValutaDest.ItemsSource = listaCurs;
        pickerValutaSursa.SelectedIndex = 0;
        pickerValutaDest.SelectedIndex = 4;
    }

    private void ButtonConverteste_Clicked(object sender, EventArgs e)
    {
        /*
         1. preluare valoare convertit entryValoare.Text ->double
         2. preluare curs sursa pickerValutaSursa.SelectedItem ->Curs
         3. preluare curs sursa pickerValutaDest.SelectedItem ->Curs
         4. calcul conversie : rezultat
         5. afisare rezultat: entryRezultat.Text <- rezultat
         */

        double valoare = 0;
        Double.TryParse(entryValoare.Text, out valoare);
        Curs cursSursa=pickerValutaSursa.SelectedItem as Curs;
        Curs cursDest=pickerValutaDest.SelectedItem as Curs;

        //4.

        //double rezultat= valoare * ((cursSursa.Value / (cursSursa?.Multiplier ?? 1)) / (cursDest.Value / (cursDest?.Multiplier ?? 1)));
        
        double rezultat = valoare * (cursSursa.Value / cursSursa.Multiplier) / (cursDest.Value / cursDest.Multiplier);
        double rezultatValueRound = Math.Round(rezultat, 4);
        entryRezultat.Text = rezultatValueRound.ToString();



        
    }
}