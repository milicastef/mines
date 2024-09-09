namespace Minesweeper.Models
{
    public class Game
    {
        private readonly Board _board;
        private readonly Player _player;

        public Game(Board board, Player player)
        {
            _board = board;
            _player = player;
        }

        public void Start()
        {
            while (_player is { HasWon: false, LivesLeft: > 0 })
            {
                Console.Clear();
                _board.Display(_player.Moves);
                Console.WriteLine($"Lives left: {_player.LivesLeft}, Moves: {_player.Moves.TakenMoves.Count}");
                Console.WriteLine("Enter move (up, down, left, right, enter):");

                var userInput = Console.ReadKey();
                var newPosition = _board.GetNewPosition(_player.Moves.CurrentPosition, userInput.Key);
                

                _player.Move(newPosition);

                if (userInput.Key == ConsoleKey.Enter)
                {
                    _player.MakeMove(newPosition);
                    
                    if (_board.HasMine(newPosition))
                    {
                        _player.LoseLife();
                        Console.WriteLine("You hit a mine! Lost one life.");
                    }
                    if (_board.IsWon(_player))

                    {
                        _player.Win();
                    }
                }
            }

            if (_player.HasWon)
            {
                Console.WriteLine($"Congratulations! You won in {_player.Moves.TakenMoves.Count} moves.");
                _board.DisplayAll();
            }
            else
            {
                Console.WriteLine("Game over! You ran out of lives.");
                _board.DisplayAll();
                Console.ReadKey();
            }
        }
    }
}
