using Microsoft.Maui.Controls;
namespace TamagotchiMauiApp;

public partial class ButtonBrowseContentView : ContentView
{
	public ButtonBrowseContentView()
    {
        InitializeComponent();
	}

	private void ToFoodHallFunction(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FoodPage());
    }

    private void ToSlurpHallFunction(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SlurpPage());
    }

    private void ToMainHallFunction(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void ToSexHallFunction(object sender , EventArgs e)
    {
        Navigation.PushAsync(new SexPage());
    }
}