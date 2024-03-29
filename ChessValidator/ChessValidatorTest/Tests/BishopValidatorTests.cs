using ChessValidator.Models;
using ChessValidator.Validators;

namespace ChessValidatorTest.Tests
{
    [TestClass]
    public class BishopValidatorTests
    {
        private BishopMoveValidator bishopMoveValidator;
        public BishopValidatorTests()
        {
            bishopMoveValidator = new BishopMoveValidator();
        }

        [TestMethod]
        public void validMoveAndCaptureMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            board.MovePiece(new Position("b2"), new Position("b3"));
            Assert.AreEqual(true, bishopMoveValidator.ValidateMove(board, new Position("c1"), new Position("a3")));
            board.MovePiece(new Position("c1"), new Position("a3"));
            // Capture Move
            Assert.AreEqual(true, bishopMoveValidator.ValidateMove(board, new Position("a3"), new Position("e7")));
        }

        [TestMethod]
        public void inValidMoveTest()
        {
            Board board = new Board();
            board.Initialize();
            Assert.AreEqual(false, bishopMoveValidator.ValidateMove(board, new Position("c1"), new Position("a3")));
        }
    }
}

