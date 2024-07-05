using System.Text;
using TicTacToeConsole;

int input;
string playGame = "Y";

GameState game = new GameState();
Logging gameLog = new Logging();
gameLog.Log("program launched");

while (playGame == "Y")
{
    Console.WriteLine("Tic Tac Toe Game");
    gameLog.Log("new game started");

    while (!game.GameOver)
    {
        game.PrintGrid();
        Console.WriteLine("Enter a number between 1 and 9, or 0 to reset game...");
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            game.MakeMove(input);
            gameLog.Log("player " + game.CurrentPlayer + " successfully played at square " + input);
        }
        catch { }
    }

    game.PrintGrid();
    Console.WriteLine("Winner: " + game.Winner);
    gameLog.Log("player " + game.CurrentPlayer + " won");

    Console.WriteLine("Play again? Y/N");
    playGame = Console.ReadLine();

    if (playGame == "Y")
    {
        game.ResetGameState();
    }
}

//Console.WriteLine("Press any key to exit...");
//Console.ReadKey();
gameLog.Log("game ended, app closed");
Console.WriteLine("DONE");