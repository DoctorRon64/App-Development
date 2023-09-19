using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace TamagotchiMauiApp;
public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	public float Hunger { get; set; } = 0.0f;
	public string HungerText => Hunger switch
	{
		0.0f => "Mijn buik is lekker rond! ",
		<= 25.0f => "O een kleine lekkere late night snack kan er wel in. ",
		<= 50.0f => "Ah Ooooh De lunch begint eraan te komen. ",
		<= 75.0f => "IK ZO'N ERGE HONGER!!!!! ",
		<= 85.0f => "OMG JE ZIET MIJN BOTTEN BIJNA ZO VEEL HONGER HEB IK!!!",
		<= 90.0f => "Ik sterf!",
		<= 100.0f => "Dag mijn Jongen",
		_ => throw new ArgumentException("Impossible")
	};
	//public string HungerTextAmount => Hunger.ToString();

	public MainPage()
	{
		BindingContext = this;

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

	private void GiveFood_Clicked(object sender, EventArgs e)
	{
		if (Hunger <= 100.0f)
		{
			Hunger += 1.0f;
		}
		HungerAmountText.Text = $"Clicked {Hunger} time";
	}
}
