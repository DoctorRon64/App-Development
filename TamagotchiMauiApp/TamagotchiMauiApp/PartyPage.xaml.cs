namespace TamagotchiMauiApp;

public partial class PartyPage : ContentPage
{
	public PartyPage()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

        float decreaseAmount = myCreaturePet.Loneliness * 0.1f;
        myCreaturePet.Loneliness -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}