using SQLite;

namespace GoldPizza.Models
{
    public class Pizzeria
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Nazwa { get; set; }
        public string Ocena { get; set; }
        public string Opis { get; set; }
    }
}