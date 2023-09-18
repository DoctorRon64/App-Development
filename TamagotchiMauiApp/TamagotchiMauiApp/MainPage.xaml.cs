using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace TamagotchiMauiApp;
public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	private float Hunger { get; set; } = 100.0f;
	public string HungerText => Hunger switch
	{
		0 => "Mijn buik is lekker rond! ",
		< 25 => "O een kleine lekkere late night snack kan er wel in. ",
		< 50 => "Ah Ooooh De lunch begint eraan te komen. ",
		< 75 => "IK ZO'N ERGE HONGER!!!!! ",
		< 85 => "OMG JE ZIET MIJN BOTTEN BIJNA ZO VEEL HONGER HEB IK!!!",
		< 90 => "Ik sterf!",
		< 100 => "Dag mijn Jongen",
	};

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

	private void GeefEten(object sender, EventArgs e)
	{
		Hunger -= 1.0f;
	}

	private void ToSlurpHallFunction(object sender, EventArgs e)
	{
		SemanticScreenReader.Default.Announce("To Slurp Hall");
		Navigation.PushAsync(new SlurpPage());
	}
}

