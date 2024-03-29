using ChessValidator.Models;
using ChessValidator.Validators;

namespace ChessValidatorTest.Tests
{
    [TestClass]
    public class KnightValidatorTests
    {
        private KnightMoveValidator knightMoveValidator;
        public KnightValidatorTests()
        {
            knightMoveValidator = new KnightMoveValidator();
        }

        [TestMethod]
        public void validMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            Assert.AreEqual(true, knightMoveValidator.ValidateMove(board, new Position("b1"), new Position("c3")));
        }

        [TestMethod]
        public void captureMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            board.MovePiece(new Position("b1"), new Position("c3"));
            board.MovePiece(new Position("b3"), new Position("b5"));
            Assert.AreEqual(true, knightMoveValidator.ValidateMove(board, new Position("c3"), new Position("b5")));
        }

        [TestMethod]
        public void inValidMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            Assert.AreEqual(false, knightMoveValidator.ValidateMove(board, new Position("b1"), new Position("d2")));
        }
    }
}

