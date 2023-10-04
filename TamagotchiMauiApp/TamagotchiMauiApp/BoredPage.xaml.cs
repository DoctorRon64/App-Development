using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp;

public partial class BoredPage : ContentPage, INotifyPropertyChanged
{
    public string StatusText { get; set; }

    public BoredPage()
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

		if (myCreaturePet != null )
		{
			StatusText = myCreaturePet.Boredom switch
			{
				<= 5.0f => "I am so hyped, I'm doing the 'Rickroll'",
				<= 20f => "I am vibing",
				<= 40f => "I am questioning my life choices right now",
				<= 60f => "Cookie clicker is fine by me",
				<= 80f => "Meh, I am literally playing Clash of Clans now",
				<= 100 => "I AM SOOOO BORED! IT'S GAME OVER FOR ME",
				_ => throw new Exception("Impossible")
			};
		}
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var Button = (ImageButton)sender;
        await Button.ScaleTo(1.05, 250);
        await Button.ScaleTo(1, 250);

        await movingImage.RotateTo(5, 100, Easing.SinInOut);
        await movingImage.RotateTo(0, 100, Easing.SinInOut);

        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

		float decreaseAmount = myCreaturePet.Boredom * 0.1f;
		myCreaturePet.Boredom -= decreaseAmount;

		await dataStore.UpdateItem(myCreaturePet);
	}
}
