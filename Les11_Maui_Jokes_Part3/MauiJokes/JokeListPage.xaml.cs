using MauiJokes.ViewModels;

namespace MauiJokes;

public partial class JokeListPage : ContentPage
{
	public JokeListPage(JokeListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}