using System;

using GoldPizza.Models;

namespace GoldPizza.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Pizzeria Pizzeria { get; set; }
        public ItemDetailViewModel(Pizzeria pizzeria = null)
        {
            Title = pizzeria?.Nazwa;
            Pizzeria = pizzeria;
        }
    }
}
