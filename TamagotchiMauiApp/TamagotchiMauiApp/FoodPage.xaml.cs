using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp;

public partial class FoodPage : ContentPage, INotifyPropertyChanged
{
	public float Hunger { get; set; } = 100f;

	public string HungerText => Hunger switch
	{
		>= 100f => "Mijn buik is lekker rond! ",
		>= 90f => "O een kleine lekkere late night snack kan er wel in. ",
		>= 85f => "Ah Ooooh De lunch begint eraan te komen. ",
		>= 75f => "IK ZO'N ERGE HONGER!!!!! ",
		>= 50f => "OMG JE ZIET MIJN BOTTEN BIJNA ZO VEEL HONGER HEB IK!!!",
		>= 25f => "HELP HELP IK STIK ZO VAN DE HONGER!!!",
		> 0f => "IK ZOU LETTERLIJK ALLES OP ETEN VOORDAT IK STERF",
		0f => "Ik sterf!",
		_ => throw new Exception("Impossible")
	};

	public string HungerTextAmount => Hunger.ToString();

	public FoodPage()
	{
		BindingContext = this;
		InitializeComponent();

		var timer = new System.Timers.Timer()
		{
			Interval = 1000.0,
			AutoReset = true,
		};

		timer.Elapsed += Timer_Elapsed;
		timer.Start();
	}

	private void Timer_Elapsed(object sender, ElapsedEventArgs e)
	{
		Hunger -= 1f;
	}
}