using Moq;

namespace Minesweeper.Tests
{
    public class BoardTests
    {
        private readonly MineGenerator _generator;
        private readonly Board _board;

        public BoardTests()
        {
            int size = 4;
            _generator = new MineGenerator();
            //_generator.Setup(x=> x.GenerateMines(size))
            //    .Returns(It.IsAny<>())
            _board = new Board(4, _generator);
        }

        public void GetNewPosition_Tests()
        {
            // Arrange
            Position position = new Position(2,3);
            //_board.GetNewPosition(position, )
        }
    }
}
