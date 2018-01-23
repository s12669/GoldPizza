using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GoldPizza.Models;

[assembly: Xamarin.Forms.Dependency(typeof(GoldPizza.Services.MockDataStore))]
namespace GoldPizza.Services
{
    public class MockDataStore : IDataStore<Pizzeria>
    {
        List<Pizzeria> pizzerie;

        public MockDataStore()
        {
            this.pizzerie = new List<Pizzeria>();
            var mockPizzerie = new List<Pizzeria>
            {
                new Pizzeria { Id = Guid.NewGuid().ToString(), Nazwa = "Salsa", Ocena="5", Opis="Bardzo dobra pizza, wysokiej jakości składniki, dobry kandydat na miano Złotej Pizzy." },
                new Pizzeria { Id = Guid.NewGuid().ToString(), Nazwa = "Dragon Pizza", Ocena="4", Opis="Zwykle dobra pizza, czasami jednak zdarza się bardzo tłusta. Bardzo dobry kurczak." },
                new Pizzeria { Id = Guid.NewGuid().ToString(), Nazwa = "Domino's", Ocena="4", Opis="Pizza bardzo dobra, ale droga. Niespecjalnie dobry sos pomidorowy nadrabiają możliwością wyboru sosu barbecue." },
                new Pizzeria { Id = Guid.NewGuid().ToString(), Nazwa = "Telepizza", Ocena = "3", Opis="Podobnie jak Domino's, sieciówka opierająca się na promocjach. Dobry sos jalapeno, średniej jakości składniki." },
                new Pizzeria { Id = Guid.NewGuid().ToString(), Nazwa = "Gusto notte", Ocena = "4", Opis="Pizza w sumie niespecjalnie dobra, ale jakoś tak je się ją łatwo i przyjemnie. Pizzeria nocna." },
                new Pizzeria { Id = Guid.NewGuid().ToString(), Nazwa = "Pizzeria PRL", Ocena = "2", Opis="Niedobry sos, co sprawia, że cała pizza nie jest zbyt smaczna." },
            };

            foreach (var pizzeria in mockPizzerie)
            {
                this.pizzerie.Add(pizzeria);
            }
        }

        public async Task<bool> AddItemAsync(Pizzeria pizzeria)
        {
            pizzerie.Add(pizzeria);
           // DatabaseHelper.Insert(ref Pizzeria);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Pizzeria pizzeria)
        {
            var _pizzeria = pizzerie.Where((Pizzeria arg) => arg.Id == pizzeria.Id).FirstOrDefault();
            pizzerie.Remove(_pizzeria);
            pizzerie.Add(pizzeria);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Pizzeria pizzeria)
        {
            var _item = pizzerie.Where((Pizzeria arg) => arg.Id == pizzeria.Id).FirstOrDefault();
            pizzerie.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Pizzeria> GetItemAsync(string id)
        {
            return await Task.FromResult(pizzerie.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Pizzeria>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(pizzerie);
        }
    }
}