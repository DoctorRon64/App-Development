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
    }
}
