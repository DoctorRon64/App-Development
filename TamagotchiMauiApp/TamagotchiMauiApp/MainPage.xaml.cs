using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
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
		public string PetNameText { get; set; } = null;

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
			var dataStore = DependencyService.Get<IDataStore<Creature>>();
			myCreaturePet = await dataStore.ReadItem();
			
			if (myCreaturePet != null )
			{
				IsEntryVisible = false;
				IsEntryVisible = false;
                PetNameText = $"{myCreaturePet.Name}";
            } 
			else
			{
				IsEntryVisible = true;
			}

            Entry entry = new Entry { Placeholder = PetNameText };
			entry.Completed += OnEntryCompleted;

            OnPropertyChanged(nameof(myCreaturePet));
            OnPropertyChanged(nameof(IsEntryVisible));
            OnPropertyChanged(nameof(PetNameText));
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;

            var dataStore = DependencyService.Get<IDataStore<Creature>>();
            string computerName = Dns.GetHostName();
            myCreaturePet = CreateCreature(text, computerName);
            var result = dataStore.CreateItem(myCreaturePet);

            IsEntryVisible = false;
            PetNameText = $"{myCreaturePet.Name}";
        }


        Creature CreateCreature(string name, string username)
		{
			Creature myCreaturePet = new Creature
			{
				Id = 0,
				Name = name,
				UserName = username,
				Hunger = 0f,
				Thirst = 0f,
				Tired = 0f,
				Boredom = 0f,
				Loneliness = 0f,
				Stimulated = 0f,
			};
			return myCreaturePet;
		}

        void ClearPetData(object sender, EventArgs e)
        {
            var dataStore = DependencyService.Get<IDataStore<Creature>>();
            var result = dataStore.DeleteItem(myCreaturePet);

            PetNameText = null;
            IsEntryVisible = true;
        }

    }
}
