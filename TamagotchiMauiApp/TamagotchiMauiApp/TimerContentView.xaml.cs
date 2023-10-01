using System;
using System.ComponentModel;
using System.Timers;
using Microsoft.Maui.Controls;

namespace TamagotchiMauiApp
{
    public partial class TimerContentView : ContentView, INotifyPropertyChanged
    {
        public float ElapsedTime => Preferences.Get("timeElapsed", 0.0f);
        public Creature myCreaturePet { get; set; }

        Random random = new Random();
        float minValue = .000001f;
        float maxValue = .01f;
        float alphaValue = 2.0f;

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
                float IncreaseInterval = (float)((float)(Math.Pow(maxValue, alphaValue + 1) - Math.Pow(minValue, alphaValue + 1)) * (float)random.NextDouble() + Math.Pow(minValue, alphaValue + 1));
                IncreaseInterval = (float)Math.Pow(IncreaseInterval, 1.0 / (alphaValue + 1));

                SetCreatureProperties(myCreaturePet, IncreaseInterval);
                await dataStore.UpdateItem(myCreaturePet);
            }

            if (ElapsedTime != 0.0f && myCreaturePet != null)
            {
                SetCreatureProperties(myCreaturePet, ElapsedTime);   
                Preferences.Set("timeElapsed", 0.0f);
            }
        }

        private void SetCreatureProperties(Creature _creature, float _value)
        {
            var properties = _creature.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.PropertyType == typeof(float))
                {
                    float newValue = (float)propertyInfo.GetValue(_creature) + _value;
                    propertyInfo.SetValue(_creature, Math.Min(newValue, 100f));
                }
            }
        }
    }
}
