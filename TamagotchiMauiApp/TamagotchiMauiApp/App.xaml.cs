﻿namespace TamagotchiMauiApp
{
    public partial class App : Application
    {
        private DateTime appResumeTime;
        private TimeSpan timeAway;

        public App()
        {
            DependencyService.RegisterSingleton<IDataStore<Creature>>(new RemoteDataStore());
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Preferences.Set("timeElapsed", 0);

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
