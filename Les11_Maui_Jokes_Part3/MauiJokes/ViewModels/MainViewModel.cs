using MauiJokes.ViewModels.Base;
using MauiJokesBL.Factories;
using MauiJokesBL.Services;
using System.Windows.Input;

namespace MauiJokes
{
    public class MainViewModel : ViewModel
    {
        private JokeService JokeService { get; init; }

        private string _jokeText;
        public string JokeText
        {
            get => _jokeText;
            set
            {
                _jokeText = value;

                NotifyPropertyChanged();
            }
        }

        private string _newJokeText;
        public string NewJokeText
        {
            get => _newJokeText;
            set
            {
                _newJokeText = value;

                NotifyPropertyChanged();
            }
        }

        public ICommand RandomJokeCommand { get; init; }
        public ICommand AddNewJokeCommand { get; init; }

        public MainViewModel(JokeService jokeService)
        {
            JokeService = jokeService;

            RandomJokeCommand = new Command(OnRandomJoke);
            AddNewJokeCommand = new Command(OnAddNewJoke);
        }

        private void OnAddNewJoke()
        {
            if (!string.IsNullOrWhiteSpace(NewJokeText))
            {
                JokeService.AddJoke(JokeFactory.Create(NewJokeText));

                // We maken de textbox (Entry) leeg. Doordat de binding in 2 richting werkt zal deze zich gesynchronizeerd houden met NewJokeText
                NewJokeText = null;

                //DisplayAlert("Toegevoegd", "De grap is toegevoegd", "Sluiten");
            }
            else
            {
                //DisplayAlert("Gefaald", "Er is geen grap ingevoerd", "Sluiten");
            }
        }

        internal void OnRandomJoke()
        {
            JokeText = JokeService.GetRandomJoke()?.Text;
        }
    }
}
