using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EventsLibrary;

namespace Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameManager _gameManager;   
        public MainWindow()
        {
            InitializeComponent();
            _gameManager = new GameManager();
            _gameManager.NumberGuessedEvent += GameManager_OnNumberGuessedEvent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var guessedNumber = NumberTextBox.Text;
            try
            {
                _gameManager.MakeGuess(int.Parse(guessedNumber));
            }
            catch
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void GameManager_OnNumberGuessedEvent(object? sender, GameFinishedEventArgs e)
        {
            GuessedTextBlock.Text = $"You have guessed it! It was {e.WinningNumber}";
            GuessedTextBlock.Visibility = Visibility.Visible;
            e.StartNewGame = StartNewGameCheckBox.IsChecked ?? false;
        }
    }
}
