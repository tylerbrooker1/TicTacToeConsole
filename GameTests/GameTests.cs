using TicTacToeConsole;

// Unit Testing class for TicTacToe game
namespace GameTests
{
    [TestClass]
    public class GameTests
    {
        private GameState game;

        [TestMethod]
        public void Test_GameStartsWithPlayerX()
        {
            game = new GameState();
            Assert.AreEqual(Player.X, game.CurrentPlayer);
        }

        [TestMethod]
        public void Test_PlayerXToPlayerO()
        {
            game = new GameState();
            game.SwitchPlayer(); // should switch from X to O
            Assert.AreEqual(Player.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void Test_PlayerOToPlayerX()
        {
            game = new GameState();
            game.SwitchPlayer(); // should switch from X to O
            game.SwitchPlayer(); // should switch from O to X
            Assert.AreEqual(Player.X, game.CurrentPlayer);
        }

        [TestMethod]
        public void Test_IsGridEmptyAtStart()
        {
            game = new GameState();
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.IsTrue(game.CanMakeMove(r,c), "Space {0},{1} is filled", r, c);
                }

            }
        }

        [TestMethod]
        public void Test_IsGridEmptyAtReset()
        {
            game = new GameState();
            game.ResetGameState();
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.IsTrue(game.CanMakeMove(r, c), "Space {0},{1} is filled", r, c);
                }

            }
        }

        [TestMethod]
        public void Test_IsGridFullAfterAGame()
        {
            /*
             
                         X O X
            Outcome:     O X O
                         O X X

             */
            game = new GameState();
            game.MakeMove(0, 0);
            game.MakeMove(0, 1);
            game.MakeMove(0, 2);
            game.MakeMove(1, 0);
            game.MakeMove(1, 1);
            game.MakeMove(1, 2);
            game.MakeMove(2, 1);
            game.MakeMove(2, 0);
            game.MakeMove(2, 2);
            game.PrintGrid(); 
            Assert.IsTrue(game.IsGridFull(), "The grid is not returning as full.");
        }
    }
}