namespace Minesweeper.Models
{
    public class Player
    {
        public int InitialLives { get; private set; }
        public int LivesLeft { get; private set; }
        public Moves Moves { get; }
        public bool HasWon { get; private set; }

        public Player(int initialLives)
        {
            InitialLives = initialLives;
            LivesLeft = initialLives;
            Moves = new Moves();
            HasWon = false;
        }

        public void Move(Position newPosition)
        {
            Moves.SetCurrentPosition(newPosition);
        }

        public void MakeMove(Position position)
        {
            if (!Moves.AlreadyTaken(position))
            {
                Moves.Make(new Move(position));
            }
        }

        public void LoseLife()
        {
            LivesLeft--;
        }

        public void Win()
        {
            HasWon = true;
        }
    }
}
