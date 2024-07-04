using System.Transactions;
using TicTacToeConsole;

int input;
string playGame = "Y";

GameState game = new GameState();

while (playGame == "Y")
{
    Console.WriteLine("Tic Tac Toe Game");

    while (!game.GameOver)
    {
        Console.WriteLine("Current Game:");
        game.PrintGrid();
        Console.WriteLine("Current Player: " + game.CurrentPlayer);
        Console.WriteLine("Enter a number between 1 and 9, or 0 to reset game...");
        input = Convert.ToInt32(Console.ReadLine());
        game.MakeMove(input);
    }

    game.PrintGrid();
    Console.WriteLine("Winner: " + game.Winner);

    Console.WriteLine("Play again? Y/N");
    playGame = Console.ReadLine();

    if (playGame == "Y")
    {
        game.ResetGameState();
    }
}

//Console.WriteLine("Press any key to exit...");
//Console.ReadKey();

Console.WriteLine("DONE");