using MauiJokesBL.Models;
using MauiJokesBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokesBL.Factories
{
    public static class JokeFactory
    {
        public static Joke Create(string text)
        {
            return new Joke { Text = text };
        }
    }
}
