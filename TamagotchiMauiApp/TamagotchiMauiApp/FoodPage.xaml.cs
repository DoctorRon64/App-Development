using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp;

public partial class FoodPage : ContentPage, INotifyPropertyChanged
{
	

	

	public FoodPage()
	{
		BindingContext = this;
		InitializeComponent();
	}
    
}