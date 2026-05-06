using MauiJokesBL.Interfaces;
using MauiJokesBL.Models;

namespace MauiJokesBL.Services
{
    public class JokeService(IJokeRespository jokeRespository)
    {
        private IJokeRespository JokeRespository { get; } = jokeRespository;

        private Joke? _previousJoke = null;

        public Joke? GetRandomJoke()
        {
            var jokeCount = JokeRespository.GetCount();
            
            if (jokeCount == 0)
                return null;

            if (jokeCount == 1)
                return JokeRespository.Get(0);

            Joke? joke = null;
            do
            {
                joke = JokeRespository.Get(Random.Shared.Next(jokeCount));
            }
            while (joke?.Text == _previousJoke?.Text); // Making sure the joke is different than the previous one

            // Keeping track of the joke, so we can select a different one next time. (We keep track of the joke and not the index, so that when jokes get added, or resorted, it still keeps track)
            // And return the joke
            return _previousJoke = joke;
        }

        public void AddJoke(Joke joke)
        {
            ArgumentNullException.ThrowIfNull(joke);

            if (!JokeRespository.Exists(joke))
                JokeRespository.Add(joke);
        }

        public bool DeleteJoke(Joke joke)
        {
            ArgumentNullException.ThrowIfNull(joke);

            if (JokeRespository.Exists(joke))
                return JokeRespository.Delete(joke);

            return false;
        }

        public List<Joke> GetJokes()
        {
            return JokeRespository.GetJokes();
        }
    }
}
