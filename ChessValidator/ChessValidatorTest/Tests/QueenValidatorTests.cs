using ChessValidator.Models;
using ChessValidator.Validators;

namespace ChessValidatorTest.Tests
{
    [TestClass]
    public class QueenValidatorTests
    {
        private QueenMoveValidator queenMoveValidator;
        public QueenValidatorTests()
        {
            queenMoveValidator = new QueenMoveValidator();
        }

        [TestMethod]
        public void inValidMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            Assert.AreEqual(false, queenMoveValidator.ValidateMove(board, new Position("d1"), new Position("d2")));
            Assert.AreEqual(false, queenMoveValidator.ValidateMove(board, new Position("d1"), new Position("d3")));
        }
    }
}

