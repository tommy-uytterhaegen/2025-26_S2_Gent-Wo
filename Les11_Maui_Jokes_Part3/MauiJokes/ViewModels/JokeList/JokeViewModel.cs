using MauiJokes.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokes.ViewModels.JokeList
{
    public class JokeViewModel : ViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;

                NotifyPropertyChanged();
            }
        }
    }
}
