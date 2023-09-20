namespace TamagotchiMauiApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
	protected override void OnSleep()
	{
		base.OnSleep();

		var sleepTime = DateTime.Now;
		Preferences.Set("sleepTime", sleepTime);
	}

	protected override void OnResume()
	{
		base.OnResume();

		var wakeTime = DateTime.Now;
		var sleepTime = Preferences.Get("sleepTime", wakeTime);


		var timeElapsed = wakeTime - sleepTime;
	}
}
