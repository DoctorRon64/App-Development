using System.Timers;

namespace TamagotchiMauiApp;

public partial class FoodPage : ContentPage
{
    public string StatusText { get; set; }

    public FoodPage()
    {
		var Timer = new System.Timers.Timer()
		{
			Interval = 500,
			AutoReset = true,
		};
		Timer.Elapsed += Timer_Elapsed;
		Timer.Start();

		BindingContext = this;
        InitializeComponent();
	}

	private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
	{
		var dataStore = DependencyService.Get<IDataStore<Creature>>();
		Creature myCreaturePet = await dataStore.ReadItem();
		StatusText = myCreaturePet.Hunger switch
		{
			<= 5.0f => "ougghhhg so full",
			<= 20f => "I could Use a late night snack",
			<= 40f => "I love that food",
			<= 60f => "I wonder what's for dinner",
			<= 80f => "I’ll have two number 9s, a number 9 large, a number 6 with extra dip, a number 7, two number 45s, one with cheese, and a large soda.",
			<= 100 => "A UHM SOOOO HUNGRY I AM STARVIN I'LL LITERALLY EAT A SUPREME BRICK",
			_ => throw new Exception("Impossible")
		};
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var Button = (ImageButton)sender;
        await Button.ScaleTo(1.05, 250);
        await Button.ScaleTo(1, 250);

        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

		float decreaseAmount = myCreaturePet.Hunger * 0.1f;
        myCreaturePet.Hunger -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}