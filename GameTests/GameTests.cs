using TicTacToeConsole;

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
    }
}