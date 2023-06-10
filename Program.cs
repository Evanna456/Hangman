using System;
using Hangman;

namespace Hangman
{
    class Program
    {
        private static void Main(string[] args)
        {
            Hangman _hangman = new Hangman();
            try {
            _hangman.play();
            }catch(Exception ex){
            Console.WriteLine("Wrong Input/s");
            _hangman.play();
            }
        }
    }
}