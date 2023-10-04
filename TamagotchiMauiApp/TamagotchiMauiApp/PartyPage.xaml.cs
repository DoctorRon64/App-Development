using System.Timers;

namespace TamagotchiMauiApp;

public partial class PartyPage : ContentPage
{
    public string StatusText { get; set; }

    public PartyPage()
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
		if (myCreaturePet != null)
		{
			StatusText = myCreaturePet.Loneliness switch
			{
				<= 5.0f => "YEAH just came back from the party with my friends",
				<= 20f => "Idd stay on my phone and scroll on tiktok",
				<= 40f => "Where is everyone",
				<= 60f => "HELLO????",
				<= 80f => "WHY IS ITT SOOO QUIETT",
				<= 100 => "I AM SO SCARED SO ALONE GIVE ME FRIENDS",
				_ => throw new Exception("Impossible")
			};
		}
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var Button = (ImageButton)sender;
        await Button.ScaleTo(1.05, 250);
        await Button.ScaleTo(1, 250);

        await movingImage.TranslateTo(-100, 0, 100);
        await movingImage.TranslateTo(100, 0, 100);
        await movingImage.TranslateTo(-100, 0, 100);
		await movingImage.TranslateTo(0, 0, 100);

        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

		float decreaseAmount = myCreaturePet.Loneliness * 0.1f;
        myCreaturePet.Loneliness -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}