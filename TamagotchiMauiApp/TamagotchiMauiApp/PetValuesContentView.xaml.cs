using Newtonsoft.Json;

namespace TamagotchiMauiApp;

public partial class PetValuesContentView : ContentView
{
	public Creature creatureDataText
	{
		get { return (Creature)GetValue(creatureDataTextProperty); }
		set { SetValue(creatureDataTextProperty, value); }
	}

	public static readonly BindableProperty creatureDataTextProperty = BindableProperty.Create(nameof(creatureDataText), typeof(Creature), typeof(PetValuesContentView));

	public PetValuesContentView()
	{
		BindingContext = this;
		InitializeComponent();
	}
}