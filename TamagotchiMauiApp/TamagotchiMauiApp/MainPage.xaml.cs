using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;

namespace TamagotchiMauiApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public float Hunger { get; set; } = 100f;

        public string HungerText => Hunger switch
        {
            >= 100f => "Mijn buik is lekker rond! ",
            >= 90f => "O een kleine lekkere late night snack kan er wel in. ",
            >= 85f => "Ah Ooooh De lunch begint eraan te komen. ",
            >= 75f => "IK ZO'N ERGE HONGER!!!!! ",
            >= 50f => "OMG JE ZIET MIJN BOTTEN BIJNA ZO VEEL HONGER HEB IK!!!",
            >= 25f => "HELP HELP IK STIK ZO VAN DE HONGER!!!",
            > 0f => "IK ZOU LETTERLIJK ALLES OP ETEN VOORDAT IK STERF",
            0f => "Ik sterf!",
            _ => throw new Exception("Impossible")
        };

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

        private void GiveFood_Clicked(object sender, EventArgs e)
        {
            Hunger -= 1f;
            HungerAmountText.Text = $"Clicked {Hunger} time";
        }
    }
}
