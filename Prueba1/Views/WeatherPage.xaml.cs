namespace Prueba1.Views;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
		InitializeComponent();
	}
    private async void OnViewWeatherRecordsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//WeatherRecords");
    }
}