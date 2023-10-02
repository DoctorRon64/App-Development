using System.ComponentModel;

namespace TamagotchiMauiApp;

public partial class BoredPage : ContentPage, INotifyPropertyChanged
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

            return myCreaturePet.Boredom switch
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

    public BoredPage()
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

        if (myCreaturePet != null)
        {
            float decreaseAmount = myCreaturePet.Boredom * 0.1f;
            myCreaturePet.Boredom -= decreaseAmount;

            await dataStore.UpdateItem(myCreaturePet);
        }
    }
}
