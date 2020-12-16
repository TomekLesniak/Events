using System;
using System.Collections.Generic;
using System.Text;

namespace EventsLibrary
{
    public class GameFinishedEventArgs : EventArgs
    {
        public int WinningNumber { get; }
        public bool StartNewGame { get; set; } = false;

        public GameFinishedEventArgs(int winningNumber)
        {
            WinningNumber = winningNumber;
        }
    }
}
