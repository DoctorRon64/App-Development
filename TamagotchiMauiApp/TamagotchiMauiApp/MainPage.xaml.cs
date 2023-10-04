using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace TamagotchiMauiApp
{
	public partial class MainPage : ContentPage, INotifyPropertyChanged
	{
		public Creature myCreaturePet { get; set; } = new Creature
		{
            Id = 0,
			Name = "",
            UserName = "",
			Hunger = 0f,
            Thirst = 0f,
            Tired = 0f,
            Boredom = 0f,
            Loneliness = 0f,
            Stimulated = 0f,
		};
		public bool IsEntryVisible { get; set; } = true;
        public bool IsMonkeyVisible { get; set; } = false;
        public string PetNameText { get; set; } = null;

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            AnimateHead();

        }

        protected override async void OnAppearing()
        {
			var dataStore = DependencyService.Get<IDataStore<Creature>>();
			myCreaturePet = await dataStore.ReadItem();
			
			if (myCreaturePet != null )
			{
                DeleteButton.IsEnabled = true;
                IsEntryVisible = false;
                IsMonkeyVisible = true;
                PetNameText = $"{myCreaturePet.Name}";
            }
            else
			{
                DeleteButton.IsEnabled = false;
                IsEntryVisible = true;
                IsMonkeyVisible = false;
            }

            Entry entry = new Entry { Placeholder = PetNameText };
			entry.Completed += OnEntryCompleted;

            OnPropertyChanged(nameof(myCreaturePet));
            OnPropertyChanged(nameof(IsEntryVisible));
            OnPropertyChanged(nameof(PetNameText));
        }

        private async void AnimateHead()
        {
            await movingImage.TranslateTo(0, -10, 1000, Easing.SinInOut);
            await movingImage.TranslateTo(0, 10, 1000, Easing.SinInOut);
            AnimateHead();
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;

            var dataStore = DependencyService.Get<IDataStore<Creature>>();
            string computerName = Dns.GetHostName();
            myCreaturePet = CreateCreature(text, computerName);

            var result = dataStore.CreateItem(myCreaturePet);

            DeleteButton.IsEnabled = true;
            IsEntryVisible = false;
            IsMonkeyVisible = true;
            PetNameText = $"{myCreaturePet.Name}";
        }

        Creature CreateCreature(string name, string username)
		{
            float defaultValue = 5f;

            Creature myCreaturePet = new Creature
			{
				Id = 0,
				Name = name,
				UserName = username,
				Hunger = defaultValue,
				Thirst = defaultValue,
				Tired = defaultValue,
				Boredom = defaultValue,
				Loneliness = defaultValue,
				Stimulated = defaultValue,
            };
			return myCreaturePet;
		}

        void ClearPetData(object sender, EventArgs e)
        {
            ClearPetDataAsync();
        }

        private async void ClearPetDataAsync()
        {
            var dataStore = DependencyService.Get<IDataStore<Creature>>();

            if (myCreaturePet != null)
            {
                DeleteButton.IsEnabled = false;

                bool result = await dataStore.DeleteItem(myCreaturePet);

                DeleteButton.IsEnabled = true;

                if (result)
                {
                    DeleteButton.IsEnabled = false;
                    PetNameText = null;
                    IsEntryVisible = true;
                    IsMonkeyVisible = false;
                }
                else
                {
                    Debug.WriteLine("Failed to delete the pet.");
                }
            }
        }

    }
}
