using System;
using Hangman;

namespace Hangman
{
    class Program
    {
        private static void Main(string[] args)
        {
            Hangman _hangman = new Hangman();
            _hangman.play();
        }
    }
}