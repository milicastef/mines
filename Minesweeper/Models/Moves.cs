
namespace Minesweeper.Models
{
    public class Moves
    {
        public List<Move> TakenMoves { get; }
        public Position CurrentPosition { get; private set; }

        public Moves()
        {
            TakenMoves = [];
        }

        public bool AlreadyTaken(Position position) =>
            GetMove(position) != null;

        internal void Make(Move move)
        {
            TakenMoves.Add(move);
        }

        public Move? GetMove(Position position) => 
            TakenMoves.FirstOrDefault(move => move.Position.Row == position.Row && move.Position.Column == position.Column);

        internal void SetCurrentPosition(Position position)
        {
            CurrentPosition = position;
        }
    }
}
