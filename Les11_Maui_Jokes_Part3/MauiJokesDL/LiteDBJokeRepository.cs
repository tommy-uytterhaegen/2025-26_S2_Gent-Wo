using LiteDB;
using MauiJokesBL.Interfaces;
using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokesDL
{
    public class LiteDBJokeRepository : IJokeRespository
    {
        public DatabaseConnection Db { get; }

        public LiteDBJokeRepository(DatabaseConnection databaseConnection)
        {
            Db = databaseConnection;
        }

        public ILiteCollection<Joke> GetCollection()
        {
            // Haal de collectie op (de tabel in SQL termen)
            return Db.GetCollection<Joke>();
        }

        public void Add(Joke joke)
        {
            GetCollection().Insert(joke);
        }

        public bool Delete(Joke joke)
        {
            // We verwijderen alle grappen die dezelfde tekst hebben als de opgegeven grap
            var count = GetCollection().DeleteMany(o => o.Text == joke.Text);

            return count > 0;
        }

        public bool Exists(Joke joke)
        {
            return GetCollection().Exists(o => o.Text == joke.Text);
        }

        public Joke Get(int jokeIndex)
        {
            // We gebruiken LINQ om deze collectie te querying. Deze worden door de library omgezet naar taal die LiteDB begrijpt. 
            return GetCollection().Query()
                                  .OrderBy(o => o.Text)
                                  .Offset(jokeIndex)
                                  .Limit(1)
                                  .FirstOrDefault();
        }

        public int GetCount()
        {
            return GetCollection().Count();
        }

        public List<Joke> GetJokes()
        {
            return GetCollection().FindAll()
                                  .ToList();
        }
    }
}
