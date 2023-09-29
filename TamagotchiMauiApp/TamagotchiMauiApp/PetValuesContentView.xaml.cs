using System;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace TamagotchiMauiApp
{
	public partial class PetValuesContentView : ContentView, INotifyPropertyChanged
	{
		public Creature MyCreaturePet { get; private set; }
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		public PetValuesContentView()
		{
			InitializeComponent();
			InitializeData();
		}

		private async void InitializeData()
		{
			var dataStore = DependencyService.Get<IDataStore<Creature>>();
			MyCreaturePet = await dataStore.ReadItem();

			if (MyCreaturePet != null)
			{
				MyCreaturePet.Hunger = 100f;
				await dataStore.UpdateItem(MyCreaturePet);
			} else
			{
				MyCreaturePet = null;
			}
		}
	}
}
