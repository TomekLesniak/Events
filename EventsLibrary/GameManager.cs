using System;

namespace EventsLibrary
{
    public class GameManager
    {
        public event EventHandler<GameFinishedEventArgs> NumberGuessedEvent;

        private readonly Random _random;
        private int _numberToGuess;

        public GameManager()
        {
            _random = new Random();
            _numberToGuess = _random.Next(0, 11);
        }

        public void MakeGuess(int guess)
        {
            if (_numberToGuess != guess) return;

            var args = new GameFinishedEventArgs(_numberToGuess);
            NumberGuessedEvent?.Invoke(this, args);

            if (args.StartNewGame == true)
            {
                InitializeNewGame();
            }
        }

        private void InitializeNewGame()
        {
            _numberToGuess = _random.Next(0, 11);
        }

    }
}
