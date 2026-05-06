namespace MauiJokes
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        // TODO: Zet deze om naar de MainViewModel
        private void DeleteJokeButton_Clicked(object sender, EventArgs e)
        {
            //var isDeleted = JokeService.DeleteJoke(JokeLabel.Text);
            //if (isDeleted)
            //{
            //    DisplayAlert("Verwijderd", "De grap is verwijderd", "Sluiten");
            //    JokeLabel.Text = "";
            //}
            //else
            //    DisplayAlert("Gefaald", "De grap is NIET verwijderd", "Sluiten");
        }
    }
}
