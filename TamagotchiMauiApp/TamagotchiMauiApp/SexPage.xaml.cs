using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp;

public partial class SexPage : ContentPage, INotifyPropertyChanged
{
    public string StatusText { get; set; }

    public SexPage()
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
			StatusText = myCreaturePet.Stimulated switch
			{
				<= 5.0f => "uhh whatttt",
				<= 20f => "bro what is this",
				<= 40f => "Why does this page excist",
				<= 60f => "Sexual active",
				<= 80f => "I am horny",
				<= 100 => "GIVE ME SEX",
				_ => throw new Exception("Impossible")
			};
		}
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var Button = (ImageButton)sender;
        await Button.ScaleTo(1.05, 250);
        await Button.ScaleTo(1, 250);

		await movingImage.RotateTo(5, 100);
        await movingImage.RotateTo(-5, 100);
        await movingImage.RotateTo(0, 100);

        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

		float decreaseAmount = myCreaturePet.Stimulated * 0.1f;
        myCreaturePet.Stimulated -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}