using GoldPizza.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoldPizza
{
    class DatabaseHelper
    {
        public static bool Insert<T>(ref T data)
        {
            using (var conn = new SQLite.SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "goldpizza.db")))
            {
                conn.CreateTable<T>();
                if (conn.Insert(data) != 0)
                {
                    Console.WriteLine("Success");
                    return true;
                }

            }
            Console.WriteLine("FAIL");
            return false;
        }

        public static List<Pizzeria> GetAll()
        {
            List<Pizzeria> pizzerie = new List<Pizzeria>();
            using (var conn = new SQLite.SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "goldpizza.db")))
            {
                pizzerie = conn.Table<Pizzeria>().ToList();

            }
            return pizzerie;
        }
    }
}
