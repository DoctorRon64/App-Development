namespace TamagotchiMauiApp;

public partial class MainPage : ContentPage
{
	public MainPage()
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
}

