using System.ComponentModel;

namespace TamagotchiMauiApp;

public partial class SlurpPage : ContentPage, INotifyPropertyChanged
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

            return myCreaturePet.Thirst switch
            {
                <= 5.0f => "Nope no water needed, ill throw your bottle out the window",
                <= 20f => "A drop of water could do",
                <= 40f => "putt a beer on my tap",
                <= 60f => "Please give me that 5 liter water bottle",
                <= 80f => "I AM SO THIRSTY MY GOD",
                <= 100 => "BOYS, IK KAN ECHT NIET MEER IK HEB WATTER NODIG WATER, WATER!!!, WATERRRR!!!!",
                _ => throw new Exception("Impossible")
            };
        }
    }

    public SlurpPage()
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

        float decreaseAmount = myCreaturePet.Thirst * 0.1f;
        myCreaturePet.Thirst -= decreaseAmount;

        await dataStore.UpdateItem(myCreaturePet);
    }
}