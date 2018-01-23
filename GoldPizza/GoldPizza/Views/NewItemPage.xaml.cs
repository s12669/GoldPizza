using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GoldPizza.Models;

namespace GoldPizza.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Pizzeria Pizzeria { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Pizzeria = new Pizzeria
            {
                Nazwa = "Nazwa restauracji",
                Ocena = "Ocena w skali 1-5",
                Opis = "Opis kandydata na miano Złotej Pizzy"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            int Ocena;
            if (Pizzeria.Nazwa.Equals("") || Pizzeria.Ocena.Equals("") || Pizzeria.Opis.Equals(""))
            {
                await DisplayAlert("Puste pole", "Upewnij się, że wszystkie pola są wypełnione", "OK");
            }
            else
            {
                if (Int32.TryParse(Pizzeria.Ocena, out Ocena))
                {
                    if (Ocena < 6 && Ocena > 0)
                    {
                        MessagingCenter.Send(this, "AddItem", Pizzeria);
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await DisplayAlert("Nieprawidłowa wartość pola ocena", "Zakres możliwych do wprowadzenia ocen wynosi od 1 do 5", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Nieprawidłowa wartość pola ocena", "W polu ocena należy wprowadzić cyfrę", "OK");
                }
            }
        }
    }
}