namespace TamagotchiMauiApp;

public partial class BoredPage : ContentPage
{
	public BoredPage()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

        float decreaseAmount = myCreaturePet.Boredom * 0.1f;
        myCreaturePet.Boredom -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}