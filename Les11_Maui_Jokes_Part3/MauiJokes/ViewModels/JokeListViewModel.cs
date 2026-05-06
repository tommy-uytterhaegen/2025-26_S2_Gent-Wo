using MauiJokes.ViewModels.Base;
using MauiJokes.ViewModels.JokeList;
using MauiJokesBL.Factories;
using MauiJokesBL.Models;
using MauiJokesBL.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiJokes.ViewModels
{
    public class JokeListViewModel : ViewModel
    {
        // De collectie waar we onze CollectionView aan binden
        private ObservableCollection<JokeViewModel> _items;
        public ObservableCollection<JokeViewModel> Items
        {
            get => _items;
            set
            {
                _items = value;

                NotifyPropertyChanged();
            }
        }

        public ICommand AddItemCommand { get; init; }

        public JokeListViewModel(JokeService jokeService)
        {
            Items = new ObservableCollection<JokeViewModel>(jokeService.GetJokes()                      // Haal alle jokes op
                                                                       .Select(ConvertToViewModel));    // Converteer alle jokes naar JokeViewModels

            AddItemCommand = new Command(() =>
            {
                // Het model aanmaken
                var jokeModel = JokeFactory.Create("Item " + Items.Count);

                // Persisteren
                jokeService.AddJoke(jokeModel);

                // Item toevoegen aan de lijst, doordat we een CollectionView gebruiken met een ObservableCollection, zien we dit direct terug in de view
                Items.Add(ConvertToViewModel(jokeModel));

                // Als we items aanpassen zien we dit terug in de view
                Items[0].Text += " !";
            });
        }

        private JokeViewModel ConvertToViewModel(Joke joke)
            => new JokeViewModel { Text = joke.Text };
    }
}
