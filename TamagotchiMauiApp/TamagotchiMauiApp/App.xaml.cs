namespace TamagotchiMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<IDataStore<Creature>>(new RemoteDataStore());
            InitializeComponent();

            Preferences.Set("timeElapsed", 0.0f);
            MainPage = new AppShell();
        }

        protected override void OnResume()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.Now);
            var wakeTime = DateTime.Now;

            TimeSpan ElapsedTime = wakeTime - sleepTime;
            float timeAsleepInMilli = ElapsedTime.Milliseconds;
            Preferences.Set("timeElapsed", timeAsleepInMilli);
        }

        protected override void OnSleep()
        {
            var sleepTime = DateTime.Now;
            Preferences.Set("SleepTime", sleepTime);
        }
    }
}
