﻿using System.Text;
using System.Transactions;
using TicTacToeConsole;

int input;
string playGame = "Y";

string basePath = Directory.GetCurrentDirectory().Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];

Console.WriteLine("Base path: " + basePath);

StringBuilder sb = new StringBuilder();
sb.Append("log something").AppendLine();
sb.Append("log something").AppendLine();
Console.WriteLine(sb.ToString());
File.AppendAllText(basePath + "\\log.txt", sb.ToString());
sb.Clear();

GameState game = new GameState();

while (playGame == "Y")
{
    Console.WriteLine("Tic Tac Toe Game");

    while (!game.GameOver)
    {
        game.PrintGrid();
        Console.WriteLine("Enter a number between 1 and 9, or 0 to reset game...");
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            game.MakeMove(input);
        }
        catch { }
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