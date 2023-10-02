using System.ComponentModel;

namespace TamagotchiMauiApp;

public partial class SexPage : ContentPage, INotifyPropertyChanged
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

            return myCreaturePet.Stimulated switch
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

    public SexPage()
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

        float decreaseAmount = myCreaturePet.Stimulated * 0.1f;
        myCreaturePet.Stimulated -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}