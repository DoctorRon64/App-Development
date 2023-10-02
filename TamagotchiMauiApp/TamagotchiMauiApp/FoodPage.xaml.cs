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

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

        float decreaseAmount = myCreaturePet.Hunger * 0.1f;
        myCreaturePet.Hunger -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}