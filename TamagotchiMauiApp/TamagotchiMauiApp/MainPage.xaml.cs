using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Timers;

namespace TamagotchiMauiApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            BindingContext = this;

            InitializeComponent();
        }

		private void ToFoodHallFunction(object sender, EventArgs e)
        {
            SemanticScreenReader.Default.Announce("To Food Hall");
            Navigation.PushAsync(new FoodPage());
        }

        private void ToSlurpHallFunction(object sender, EventArgs e)
        {
            SemanticScreenReader.Default.Announce("To Slurp Hall");
            Navigation.PushAsync(new SlurpPage());
        }
    }
}
