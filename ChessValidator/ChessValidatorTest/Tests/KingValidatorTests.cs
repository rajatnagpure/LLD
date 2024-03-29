using ChessValidator.Models;
using ChessValidator.Validators;

namespace ChessValidatorTest.Tests
{
    [TestClass]
    public class KingValidatorTests
    {
        private KingMoveValidator kingMoveValidator;
        public KingValidatorTests()
        {
            kingMoveValidator = new KingMoveValidator();
        }

        [TestMethod]
        public void inValidMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            Assert.AreEqual(false, kingMoveValidator.ValidateMove(board, new Position("d1"), new Position("d2")));
            Assert.AreEqual(false, kingMoveValidator.ValidateMove(board, new Position("d1"), new Position("d3")));
        }
    }
}