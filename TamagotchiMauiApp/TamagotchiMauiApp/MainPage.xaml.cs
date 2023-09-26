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
			Name = null,
			Hunger = 100f,
            Thurst = 100f,
            Sleep = 100f,
            SexValue = 0f,
		};

		public string PetNameText { get; set; } = null;
        private IDataStore<CreaturePet> dataStore;

        private bool isEntryVisible;
        public bool IsEntryVisible
        {
            get { return isEntryVisible; }
            set
            {
                if (isEntryVisible != value)
                {
                    isEntryVisible = value;
                    OnPropertyChanged(nameof(IsEntryVisible));
                }
            }
        }

        public MainPage()
		{
			BindingContext = this;
			InitializeComponent();

            dataStore = DependencyService.Get<IDataStore<CreaturePet>>();
			myCreaturePet = dataStore.ReadItem();

            Entry entry = new Entry { Placeholder = PetNameText };
            entry.Completed += OnEntryCompleted;

            if (myCreaturePet != null && !string.IsNullOrWhiteSpace(myCreaturePet.Name))
            {
                IsEntryVisible = false;
            }
            else
            {
                IsEntryVisible = true;
            }

            PetNameText = $"{dataStore.ReadItem().Name}";
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;

            myCreaturePet.Name = text;
            dataStore.UpdateItem(myCreaturePet);
            PetNameText = $"{dataStore.ReadItem().Name}";

            IsEntryVisible = false;
        }
    }
}
