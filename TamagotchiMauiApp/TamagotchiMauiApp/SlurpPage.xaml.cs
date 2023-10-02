namespace TamagotchiMauiApp;

public partial class SlurpPage : ContentPage
{
	public SlurpPage()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

        float decreaseAmount = myCreaturePet.Thirst * 0.1f;
        myCreaturePet.Thirst -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}