using ChessValidator.Models;
using ChessValidator.Validators;

namespace ChessValidatorTest.Tests
{
    [TestClass]
    public class PawnValidatorTests
    {
        private PawnMoveValidator pawnMoveValidator;
        public PawnValidatorTests()
        {
            pawnMoveValidator = new PawnMoveValidator();
        }

        [TestMethod]
        public void initialMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            Assert.AreEqual(true, pawnMoveValidator.ValidateMove(board, new Position("a2"), new Position("a4")));
        }

        [TestMethod]
        public void validMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            board.MovePiece(new Position("a2"), new Position("a4"));
            Assert.AreEqual(true, pawnMoveValidator.ValidateMove(board, new Position("a4"), new Position("a5")));
        }

        [TestMethod]
        public void captureMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            board.MovePiece(new Position("a2"), new Position("a4"));
            board.MovePiece(new Position("b7"), new Position("b5"));
            Assert.AreEqual(true, pawnMoveValidator.ValidateMove(board, new Position("a4"), new Position("b5")));
        }

        [TestMethod]
        public void inValidMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            board.MovePiece(new Position("a2"), new Position("a4"));
            board.MovePiece(new Position("a7"), new Position("a5"));
            Assert.AreEqual(false, pawnMoveValidator.ValidateMove(board, new Position("a4"), new Position("a5")));
        }
    }
}

