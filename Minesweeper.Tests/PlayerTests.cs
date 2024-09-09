namespace Minesweeper.Tests
{
    public class PlayerTests
    {
        private readonly Player _player;
        private const int InitialLives = 3;

        public PlayerTests()
        {
            _player = new Player(InitialLives);
        }

        [Fact]
        public void LoseLife_Decrements_LivesLeft_Correctly()
        {
            // Arrange
            var position = new Position(2,3);
            _player.MakeMove(position);

            // Act
            _player.LoseLife();

            // Assert
            _player.LivesLeft.Should().Be(InitialLives - 1);
        }

        [Fact]
        public void Win_Sets_HasWon_ToTrue()
        {
            // Arrange
            Assert.False(_player.HasWon);

            // Act 
            _player.Win();

            // Assert
            _player.HasWon.Should().BeTrue();
        }

        [Fact]
        public void MakeMove_Increases_Number_Of_MovesTaken()
        {
            // Arrange
            var position = new Position(2, 3);
            _player.Moves.TakenMoves.Count.Should().Be(0);

            // Act 
            _player.MakeMove(position);

            // Assert
            _player.Moves.TakenMoves.Count.Should().Be(1);
        }

    }
}
