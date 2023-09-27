using Microsoft.Maui.Controls;
namespace TamagotchiMauiApp;

public partial class ButtonBrowseContentView : ContentView
{
	FoodPage foodPage = new FoodPage();
	MainPage mainPage = new MainPage();
	SlurpPage slurpPage = new SlurpPage();

	public ButtonBrowseContentView()
    {
        InitializeComponent();
	}

	private void ToFoodHallFunction(object sender, EventArgs e)
    {
        Navigation.PushAsync(foodPage);
    }

    private void ToSlurpHallFunction(object sender, EventArgs e)
    {
        Navigation.PushAsync(slurpPage);
    }

    private void ToMainHallFunction(object sender, EventArgs e)
    {
        Navigation.PushAsync(mainPage);
    }
}