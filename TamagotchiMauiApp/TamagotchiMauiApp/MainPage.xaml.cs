using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace TamagotchiMauiApp
{
	public partial class MainPage : ContentPage, INotifyPropertyChanged
	{
		public CreaturePet myCreaturePet { get; set; } = new CreaturePet
		{
			Name = "Default Pet Name",
			Hunger = 100f,
			Sleep = 100f,
		};

		public string petNameText { get; set; } = "Rename Your Pet";
        private IDataStore<CreaturePet> dataStore;

        public MainPage()
		{
			BindingContext = this;
			InitializeComponent();

            dataStore = DependencyService.Get<IDataStore<CreaturePet>>();
			myCreaturePet = dataStore.ReadItem();

            petNameText = $"{dataStore.ReadItem().Name} Pet";


            Entry entry = new Entry { Placeholder = "Enter text" };
			entry.TextChanged += OnEntryTextChanged;
			entry.Completed += OnEntryCompleted;
		}

		public void OnEntryTextChanged(object sender, TextChangedEventArgs e)
		{
			string oldText = e.OldTextValue;
			string newText = e.NewTextValue;
			string myText = entry.Text;
        }

        void OnEntryCompleted(object sender, EventArgs e)
		{
			string text = ((Entry)sender).Text;

            myCreaturePet.Name = text;
            dataStore.UpdateItem(myCreaturePet);
            petNameText = $"{dataStore.ReadItem().Name} Pet";
        }
    }
}
