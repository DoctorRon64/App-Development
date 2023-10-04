using Plugin.Media.Abstractions;
using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp;

public partial class SleepPage : ContentPage, INotifyPropertyChanged
{
    public string StatusText { get; set; }

    public SleepPage()
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
			StatusText = myCreaturePet.Tired switch
			{
				<= 5.0f => "Bro I just woke up, NOT THAT I AM WOKE",
				<= 20f => "A little nap could do, 5 minute break",
				<= 40f => "My bed is right there",
				<= 60f => "I AM SLEEPY AS FUCK",
				<= 80f => "MY EYES ARE RED PLEASE GIVE ME SLEEP, and putt the light out",
				<= 100 => "IF I DONT SLEEP I DIE I AM AWAKE FOR 400 HOURS",
				_ => throw new Exception("Onvoorstelbaar")
			};
		}
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var Button = (ImageButton)sender;
        await Button.ScaleTo(1.05, 250);
        await Button.ScaleTo(1, 250);

        await movingImage.RotateTo(-5, 100, Easing.SinInOut);
		await Task.Delay(100);
        await movingImage.RotateTo(5, 100, Easing.SinInOut);
        await Task.Delay(100);
        await movingImage.RotateTo(0, 100, Easing.SinInOut);

        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

		float decreaseAmount = myCreaturePet.Tired * 0.1f;
        myCreaturePet.Tired -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}