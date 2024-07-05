using System;
using System.Reflection;

// Main game functionality, to be initialised in the Program.cs class
namespace TicTacToeConsole
{
    public class GameState
    {
        public Player[,] GameGrid {  get; private set; }
        public Player CurrentPlayer {  get; private set; }
        public Player StartingPlayer { get; private set; }
        public Player Winner { get; private set; }
        public int TurnsPassed { get; private set; }
        public bool GameOver { get; private set; }

        public GameState()
        {
            GameGrid = new Player[3, 3];
            StartingPlayer = Player.X;
            CurrentPlayer = StartingPlayer;
            Winner = Player.None;
            TurnsPassed = 0;
            GameOver = false;
        }

        // Prints a current visual representation of the game grid to the console
        public void PrintGrid()
        {
            for (int r = 0; r < GameGrid.GetLength(0); r++)
            {
                for (int c = 0; c < GameGrid.GetLength(1); c++)
                {
                    Console.Write("[");
                    if (GameGrid[r, c] == Player.None)
                    {
                        Console.Write(" ");
                    } else
                    {
                        Console.Write(GameGrid[r, c]);
                    }
                    Console.Write("]");
                    Console.Write(" ");
                }
                if (r == 1)
                {
                    Console.Write("    " + CurrentPlayer + "'s turn");
                }
                Console.WriteLine();
            }
        }

        // Overload of MakeMove to allow input of 1 to 9, or 0 to reset game
        // e.g. 1 = 0,0 , 2 = 0,1 , 3 = 0,2 , 4 = 1,0 , etc.
        public bool MakeMove(int input)
        {
            bool successfulMove = false;
            switch (input) {
                case 1:
                    successfulMove = MakeMove(0, 0);
                    break;
                case 2:
                    successfulMove = MakeMove(0, 1);
                    break;
                case 3:
                    successfulMove = MakeMove(0, 2);
                    break;
                case 4:
                    successfulMove = MakeMove(1, 0);
                    break;
                case 5:
                    successfulMove = MakeMove(1, 1);
                    break;
                case 6:
                    successfulMove = MakeMove(1, 2);
                    break;
                case 7:
                    successfulMove = MakeMove(2, 0);
                    break;
                case 8:
                    successfulMove = MakeMove(2, 1);
                    break;
                case 9:
                    successfulMove = MakeMove(2, 2);
                    break;
                case 0:
                    ResetGameState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input));
            }
            return successfulMove;
        }

        // Checks if a move can be made
        private bool CanMakeMove(int r, int c)
        {
            return !GameOver && GameGrid[r, c] == Player.None;
        }

        // Checks if the grid is full
        private bool IsGridFull()
        {
            return TurnsPassed == 9;
        }

        // Switches players
        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        }

        // Need to check if a player has won the game - each of the rows/columns/diags would be marked with the same player
        private bool AreSquaresMarked((int, int)[] squares, Player player)
        {
            foreach ((int r, int c) in squares)
            {
                if (GameGrid[r, c] != player) return false;
            }

            return true;
        }

        // Check if the last move was a winning move
        private bool DidMoveWin(int r, int c)
        {
            (int, int)[] row = new[] { (r, 0), (r, 1), (r, 2) };
            (int, int)[] col = new[] { (0, c), (1, c), (2, c) };
            (int, int)[] diagForward = new[] { (2, 0), (1, 1), (0, 2) };
            (int, int)[] diagBackward = new[] { (0, 0), (1, 1), (2, 2) };

            if (AreSquaresMarked(row, CurrentPlayer))
            {
                return true;
            }

            if (AreSquaresMarked(col, CurrentPlayer))
            {
                return true;
            }

            if (AreSquaresMarked(diagForward, CurrentPlayer))
            {
                return true;
            }

            if (AreSquaresMarked(diagBackward, CurrentPlayer))
            {
                return true;
            }

            return false;
        }

        // Checks if the last move ended the game
        private bool DidMoveEndGame(int r, int c)
        {
            if (DidMoveWin(r, c))
            {
                Winner = CurrentPlayer;
                return true;
            }

            if (IsGridFull())
            {
                Winner = Player.None;
                return true;
            }
            return false;
        }

        // Sets the grid to the player's chosen move if possible, increments number of turns, progresses the game state
        public bool MakeMove(int r, int c)
        {
            if (!CanMakeMove(r, c))
            {
                return false; 
            }

            GameGrid[r, c] = CurrentPlayer;
            TurnsPassed++;

            if (DidMoveEndGame(r,c))
            {
                GameOver = true;
            }
            else
            {
                SwitchPlayer();
            }
            return true;
        }

        // Resets the game back to a beginning state
        public void ResetGameState()
        {
            GameGrid = new Player[3, 3];
            StartingPlayer = StartingPlayer == Player.X ? Player.O : Player.X;
            CurrentPlayer = StartingPlayer;
            Winner = Player.None;
            TurnsPassed = 0;
            GameOver = false;
        }
    }
}
