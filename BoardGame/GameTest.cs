using BoardGameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGameTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestRandomBoardCreatedSuccessfully_ShouldHaveCorrectSizeAndColorsNumber()
        {
            IGamingBoard board = BoardFactory.CreateRandomBoard(2, 2);
            Assert.AreEqual(2, board.GetSize(), "Board size is different than expected value = 2");
            Assert.AreEqual(2, board.GetColorsNumber(), "Number of colors for the board is different than expected value = 2");
        }

        [TestMethod]
        public void TestBoardWithTwoColorsHavingOnlyOriginDifferentThanTheOthers_PickColorShouldReturnTheCorrectColorCode()
        {
            IGamingBoard board = BoardFactory.CreateRandomBoard(2, 2);
            board.SetColor(0, 0, 1);
            board.SetColor(0, 1, 2);
            board.SetColor(1, 0, 2);
            board.SetColor(1, 1, 2);

            Assert.AreEqual(2, board.PickNextColor(), "The picked color is not the expected one : 2" );
        }

        [TestMethod]
        public void TestBoardWithThreeColors_PickColorShouldReturnTheCorrectColorCode()
        {
            IGamingBoard board = BoardFactory.CreateRandomBoard(2, 3);
            board.SetColor(0, 0, 1);
            board.SetColor(0, 1, 2);
            board.SetColor(1, 0, 3);
            board.SetColor(1, 1, 2);

            Assert.AreEqual(2, board.PickNextColor(), "The picked color is not the expected one : 2");
        }

        [TestMethod]
        public void TestBoardWithTwoColorsHavingOnlyOriginDifferentThanTheOthers_MoveNextShouldFinishTheGame()
        {
            IGamingBoard board = BoardFactory.CreateRandomBoard(2, 2);
            board.SetColor(0, 0, 1);
            board.SetColor(0, 1, 2);
            board.SetColor(1, 0, 2);
            board.SetColor(1, 1, 2);

            board.MoveNext(board.PickNextColor());

            Assert.IsTrue(board.IsGameOver(), "The game should have be over, but it's not");
        }
    }
}
