using MauiJokesBL.Factories;
using MauiJokesBL.Interfaces;
using MauiJokesBL.Models;

namespace MauiJokesDL
{
    public class DadJokeRepository : IJokeRespository
    {
        private List<Joke> _jokes;

        public DadJokeRepository()
        {
            _jokes = 
            [
                JokeFactory.Create("Awesome dad joke 1."),
                JokeFactory.Create("Awesome dad joke 2."),
                JokeFactory.Create("Awesome dad joke 3.")
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
