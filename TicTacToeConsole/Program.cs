using System.Text;
using TicTacToeConsole;

int input;
string playGame = "Y";

GameState game = new GameState();
Logging gameLog = new Logging();
gameLog.Log("program launched");

while (playGame == "Y")
{

    game.PrintGridNumbers();
    gameLog.Log("new game started");

    while (!game.GameOver)
    {
        game.PrintGrid();
        Console.WriteLine("Enter a number between 1 and 9, or 0 to reset game...");
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input: " + input);
            
            if (game.MakeMove(input))
            {
                gameLog.Log("player " + game.CurrentPlayer + " successfully played at square " + input);
            } else if (input == 0)
            {
                gameLog.Log("0 pressed, game reset");
            } else
            {
                Console.WriteLine("Invalid move - try again!");
            }
        }
        catch {
            Console.WriteLine("Invalid input - try again!");
        }
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

gameLog.Log("game ended, program closed");
Console.WriteLine("DONE");