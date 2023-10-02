namespace TamagotchiMauiApp;

public partial class PartyPage : ContentPage
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

            return myCreaturePet.Loneliness switch
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

    public PartyPage()
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

        float decreaseAmount = myCreaturePet.Loneliness * 0.1f;
        myCreaturePet.Loneliness -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}