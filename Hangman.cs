using System;
using System.Text;
using System.Text.Json;
using Models;

namespace Hangman
{
    class Hangman
    {
        public void play()
        {
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("You have 20 lives");
            string json = File.ReadAllText("./data/idioms.json");
            var result = JsonSerializer.Deserialize<AllIdioms>(json);
            int max = result.idioms.Count;
            var rnd = new Random();
            int index = rnd.Next(0, max);
            string original_sentence = result.idioms[index];
            string sentence = original_sentence.Replace(" ", "");
            List<char> uniqueSet = new List<char>();  
            for(int it=0;it < sentence.Count();it++){
                if(uniqueSet.Contains(sentence[it]) == false){
                   uniqueSet.Add(sentence[it]); 
                }
            }
            int unique_length = uniqueSet.Count();
            StringBuilder guess = new StringBuilder(original_sentence);
            for(int it=0;it < unique_length - 2;it++){
                 int unique_index = rnd.Next(0, unique_length);
                  guess.Replace(uniqueSet[unique_index].ToString(), "_");    
            }
            Console.WriteLine(guess);
        }
    }
}