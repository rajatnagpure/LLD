using ChessValidator.Models;
using ChessValidator.Validators;

namespace ChessValidatorTest.Tests
{
    [TestClass]
    public class RookValidatorTests
    {
        private RookMoveValidator rookMoveValidator;
        public RookValidatorTests()
        {
            rookMoveValidator = new RookMoveValidator();
        }

        [TestMethod]
        public void validMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            board.MovePiece(new Position("a2"), new Position("a6"));
            Assert.AreEqual(true, rookMoveValidator.ValidateMove(board, new Position("a1"), new Position("a5")));
            board.MovePiece(new Position("a1"), new Position("a5"));
            Assert.AreEqual(true, rookMoveValidator.ValidateMove(board, new Position("a5"), new Position("h5")));
        }

        [TestMethod]
        public void captureMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            board.MovePiece(new Position("a1"), new Position("a5"));
            Assert.AreEqual(true, rookMoveValidator.ValidateMove(board, new Position("a5"), new Position("a7")));
        }

        [TestMethod]
        public void inValidMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            Assert.AreEqual(false, rookMoveValidator.ValidateMove(board, new Position("a1"), new Position("a3")));
        }
    }
}

