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
            int life = 7;
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
            int ul = uniqueSet.Count();
            StringBuilder guess = new StringBuilder(original_sentence);
            for(int it=0;it < ul - 2;it++){
                  int unique_index = rnd.Next(0, ul);
                  guess.Replace(uniqueSet[unique_index].ToString(), "_");    
            }
            string hangman = "\n | \n | \n | \n O \n + \n ^";
            Console.WriteLine("Welcome to Hangman" + hangman);
            Console.WriteLine("Guess the letters to complete the sentence");
            while(guess.ToString() != original_sentence && life != 0){
                Console.WriteLine("Life: "+ life);
                Console.WriteLine(guess);
                string  x = Console.ReadLine()!;
                if(sentence.Contains(x) == true){
                   for(int it=0;it < original_sentence.Length; it++){
                      if(original_sentence[it] == x.ToCharArray()[0]){
                       guess[it] = x.ToCharArray()[0];  
                      }
                   }
                }else{
                    life = life - 1;
                }
            }
            if(life != 0){
            Console.WriteLine(guess);
            Console.WriteLine("You won");
            }else{
            Console.WriteLine("Hanged!");
            }
        }
    }
}