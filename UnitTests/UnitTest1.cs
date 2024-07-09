using TicTacToeConsole;

namespace UnitTests
{
    public class Tests
    {

        GameState game;

        [SetUp]
        public void Setup()
        {
            game = new GameState();
        }

        [Test]
        public void Test1()
        {
            // Assign

            // Act
            var isGridFull = game.IsGridFull(); // ex[ected false

            // Assert
            Assert.AreEqual(false, isGridFull);
        }
    }
}