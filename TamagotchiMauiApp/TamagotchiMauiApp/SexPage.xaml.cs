namespace TamagotchiMauiApp;

public partial class SexPage : ContentPage
{
	public SexPage()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

        float decreaseAmount = myCreaturePet.Stimulated * 0.1f;
        myCreaturePet.Stimulated -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}