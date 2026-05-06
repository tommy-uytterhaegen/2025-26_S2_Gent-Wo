using LiteDB;
using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokesDL
{
    public class DatabaseConnection
    {
        private LiteDatabase _database;

        public DatabaseConnection()
        {
            _database = new LiteDatabase("jokes.db");
        }

        public ILiteCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>();
        }

    }
}
