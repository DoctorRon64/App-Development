using System;
using System.ComponentModel;
using System.Timers;
using Microsoft.Maui.Controls;

namespace TamagotchiMauiApp
{
    public partial class TimerContentView : ContentView, INotifyPropertyChanged
    {
        public float IncreaseInterval { get; set; }
        public float ElapsedTime
        {
            get
            {
                if (Preferences.ContainsKey("timeElapsed"))
                {
                    return Preferences.Get("timeElapsed", 0);
                }
                else
                {
                    return 0;
                }
            }
        }
        private Creature myCreaturePet { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimerContentView()
        {
            InitializeComponent();
            Initialize();

            BindingContext = this;
        }

        private void Initialize()
        {
            var Timer = new System.Timers.Timer()
            {
                Interval = 1000 - Preferences.Get("TimerOfset", 0f),
                AutoReset = true,
            };
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var dataStore = DependencyService.Get<IDataStore<Creature>>();
            myCreaturePet = await dataStore.ReadItem();

            if (myCreaturePet != null)
            {
                SetCreatureProperties(-0.1f);
                await dataStore.UpdateItem(myCreaturePet);
                OnPropertyChanged("myCreaturePet");
            }

            if (ElapsedTime != 0)
            {
                SetCreatureProperties(ElapsedTime);
                Preferences.Set("timeElapsed", 0);
            }
        }

        private void SetCreatureProperties(float _value)
        {
            myCreaturePet.Hunger += _value;
            myCreaturePet.Thirst += _value;
            myCreaturePet.Boredom += _value;
            myCreaturePet.Tired += _value;
            myCreaturePet.Stimulated += _value;
            myCreaturePet.Loneliness += _value;
        }
    }
}
