namespace TamagotchiMauiApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void ToFoodHallFunction(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
		{
			ToFoodHall.Text = $"Clicked {count} time";
		}
		else
		{
			ToFoodHall.Text = $"Clicked {count} times";
		}

		SemanticScreenReader.Announce(ToFoodHall.Text);
		Navigation.PushAsync(new FoodPage());
	}

	private void ToSlurpHallFunction(object sender, EventArgs e)
	{
		Navigation.PushAsync(new SlurpPage());
	}
}

