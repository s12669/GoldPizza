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
            pizzerie = DatabaseHelper.GetAll();
        }

        public async Task<bool> AddItemAsync(Pizzeria pizzeria)
        {
            pizzerie.Add(pizzeria);
            DatabaseHelper.Insert(ref pizzeria);

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