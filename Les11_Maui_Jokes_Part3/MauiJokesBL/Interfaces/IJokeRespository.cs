using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokesBL.Interfaces
{
    public interface IJokeRespository
    {
        void Add(Joke joke);
        bool Exists(Joke joke);
        Joke Get(int jokeIndex);
        int GetCount();
        bool Delete(Joke joke);
        List<Joke> GetJokes();
    }
}
