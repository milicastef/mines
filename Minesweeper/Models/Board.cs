namespace Minesweeper.Models
{
    public class Board
    {
        private readonly bool[,] _fields;
        private readonly int _size;
        private readonly int _mines;

        public Board(int size, MineGenerator mineGenerator)
        {
            _size = size;
            _fields = mineGenerator.GenerateMines(size);
            _mines = _size;
        }

        public void Display(Moves moves)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    var position = new Position(i, j);
                    var alreadyTakenMove = moves.GetMove(position);

                    if (alreadyTakenMove != null)
                    {
                        Console.Write(HasMine(position) ? "X " : "O ");
                    }
                    else if (moves.CurrentPosition.Row == i && moves.CurrentPosition.Column == j)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }

                Console.WriteLine();
            }
        }

        public void DisplayAll()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(_fields[i, j] ? "X " : "O ");
                }

                Console.WriteLine();
            }
        }

        public bool HasMine(Position position) => _fields[position.Row, position.Column];

        public bool IsWon(Player player)
        {
            var fieldsWithoutMines = _fields.Length - _mines;
            return player.Moves.TakenMoves.Count - (player.InitialLives - player.LivesLeft) == fieldsWithoutMines;
        }

        public Position GetNewPosition(Position currentPosition, ConsoleKey direction)
        {
            var position = currentPosition;
            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    position.Row = Math.Max(0, position.Row - 1);
                    break;
                case ConsoleKey.DownArrow:
                    position.Row = Math.Min(_size - 1, position.Row + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    position.Column = Math.Max(0, position.Column - 1);
                    break;
                case ConsoleKey.RightArrow:
                    position.Column = Math.Min(_size - 1, position.Column + 1);
                    break;
            }

            return position;
        }
    }
}
