using Plugin.Media.Abstractions;
using System.ComponentModel;

namespace TamagotchiMauiApp;

public partial class SleepPage : ContentPage, INotifyPropertyChanged
{
    public Creature myCreaturePet { get; set; }
    public string StatusText
    {
        get
        {
            if (myCreaturePet == null)
            {
                return "No creature found.";
            }

            return myCreaturePet.Tired switch
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

    public SleepPage()
    {
        BindingContext = this;
        InitializeComponent();
        Initialize();
    }

    private async void Initialize()
    {
        var datastore = DependencyService.Get<IDataStore<Creature>>();
        myCreaturePet = await datastore.ReadItem();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var Button = (ImageButton)sender;
        await Button.ScaleTo(1.05, 250);
        await Button.ScaleTo(1, 250);

        var dataStore = DependencyService.Get<IDataStore<Creature>>();
        Creature myCreaturePet = await dataStore.ReadItem();

        float decreaseAmount = myCreaturePet.Tired * 0.1f;
        myCreaturePet.Tired -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}