using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp
{
	public partial class MainPage : ContentPage, INotifyPropertyChanged
	{
		public CreaturePet myCreaturePet { get; set; } = new CreaturePet
		{
			Name = "Vincent",
			Hunger = 0.4f,
			Sleep = 0.4f,
		};

		public string petNameText { get; set; }

		public MainPage()
		{
			BindingContext = this;
			InitializeComponent();
			Preferences.Clear();

			var dataStore = DependencyService.Get<IDataStore<CreaturePet>>();
			myCreaturePet = dataStore.ReadItem();
			if (myCreaturePet == null)
			{
				myCreaturePet = new CreaturePet
				{
					Name = "Vincent",
					Hunger = 0.4f,
					Sleep = 0.6f
				};
			}

			petNameText = $"{myCreaturePet.Name} Pet";

			/*string creatureString = JsonConvert.SerializeObject(myCreaturePet);
            Preferences.Set("myCreature", creatureString);
            myCreaturePet = JsonConvert.DeserializeObject<CreaturePet>(creatureString);*/

			Entry entry = new Entry { Placeholder = "Enter text" };
			entry.TextChanged += OnEntryTextChanged;
			entry.Completed += OnEntryCompleted;
		}
		void OnEntryTextChanged(object sender, TextChangedEventArgs e)
		{
			string oldText = e.OldTextValue;
			string newText = e.NewTextValue;
			string myText = entry.Text;
		}

		void OnEntryCompleted(object sender, EventArgs e)
		{
			string text = ((Entry)sender).Text;
			myCreaturePet.Name = text;
		}
	}
}
