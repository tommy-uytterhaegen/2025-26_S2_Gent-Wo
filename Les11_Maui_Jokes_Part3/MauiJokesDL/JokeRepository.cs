using MauiJokesBL.Factories;
using MauiJokesBL.Interfaces;
using MauiJokesBL.Models;

namespace MauiJokesDL
{
    public class JokeRepository : IJokeRespository
    {
        private List<Joke> _jokes;

        public JokeRepository()
        {
            _jokes = 
            [
                JokeFactory.Create("Why was the math book sad? It had too many problems." ),
                JokeFactory.Create("Why don’t programmers like nature? Too many bugs." ),
                JokeFactory.Create("I’m reading a book on anti-gravity; it’s impossible to put down." ),
                JokeFactory.Create("My code works… as long as nobody runs it." )
            ];
        }

        public void Add(Joke joke)
        {
            _jokes.Add(joke);
        }

        public bool Exists(Joke joke)
        {
            return _jokes.Contains(joke);
        }

        public Joke Get(int jokeIndex)
        {
            if (0 <= jokeIndex && jokeIndex < GetCount())
                return _jokes[jokeIndex];

            throw new InvalidDataException($"No joke with index {jokeIndex}");
        }

        public int GetCount()
        {
            return _jokes.Count;
        }

        public bool Delete(Joke joke)
        {
            _jokes.Remove(joke);

            return true;
        }

        public List<Joke> GetJokes()
        {
            return _jokes;
        }
    }
}
