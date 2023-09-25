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
        SemanticScreenReader.Default.Announce("To Food Hall");
        Navigation.PushAsync(new FoodPage());
    }

    private void ToSlurpHallFunction(object sender, EventArgs e)
    {
        SemanticScreenReader.Default.Announce("To Slurp Hall");
        Navigation.PushAsync(new SlurpPage());
    }

    private void ToMainHallFunction(object sender, EventArgs e)
    {
        SemanticScreenReader.Default.Announce("To Main Page");
        Navigation.PushAsync(new MainPage());
    }
}