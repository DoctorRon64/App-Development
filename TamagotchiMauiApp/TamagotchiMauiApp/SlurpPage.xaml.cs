using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp;

public partial class SlurpPage : ContentPage, INotifyPropertyChanged
{
    public string StatusText { get; set; }

    public SlurpPage()
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
			StatusText = myCreaturePet.Thirst switch
			{
				<= 5.0f => "Nope no water needed, I'll throw your bottle out the window",
				<= 20f => "A drop of water could do",
				<= 40f => "Put a beer on my tap",
				<= 60f => "Please give me that 5-liter water bottle",
				<= 80f => "I AM SO THIRSTY MY GOD",
				<= 100f => "BOYS, IK KAN ECHT NIET MEER IK HEB WATER NODIG WATER, WATER!!!, WATERRRR!!!!",
				_ => throw new Exception("Impossible")
			};
		}
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var Button = (ImageButton)sender;
        await Button.ScaleTo(1.05, 250);
        await Button.ScaleTo(1, 250);

        await movingImage.TranslateTo(0, 5, 200, Easing.SinInOut);
        await movingImage.TranslateTo(0, -5, 200, Easing.SinInOut);
        await movingImage.TranslateTo(0, 0, 50, Easing.SinInOut);

        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

		float decreaseAmount = myCreaturePet.Thirst * 0.1f;
        myCreaturePet.Thirst -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}