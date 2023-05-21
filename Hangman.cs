using System;
using System.Text.Json;
using Models;

namespace Hangman
{
    class Hangman
    {
        public void play()
        {
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("You have 10 lives");
            string json = File.ReadAllText("./data/idioms.json");
            var result = JsonSerializer.Deserialize<AllIdioms>(json);
            int max = result.idioms.Count;
            var rnd = new Random();
            int index = rnd.Next(0, max);
            string sentence = result.idioms[index];
            /* ... */
        }
    }
}