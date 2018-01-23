using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GoldPizza.Models;
using GoldPizza.ViewModels;

namespace GoldPizza.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var pizzeria = new Pizzeria
            {
                Nazwa = "Nazwa restauracji",
                Ocena = "Ocena restauracji w skali 1-5",
                Opis = "Opis kandydata na miano Złotej Pizzy"
            };

            viewModel = new ItemDetailViewModel(pizzeria);
            BindingContext = viewModel;
        }
    }
}