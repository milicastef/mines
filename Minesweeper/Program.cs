using Minesweeper.Models;

namespace Minesweeper;

class Program
{
    static void Main(string[] args)
    {
        // Game setup
        int boardSize = 4;  // You can adjust the board size as needed
        int initialLives = 3;  // Set the number of lives for the player

        // Create game components
        var mineGenerator = new MineGenerator();
        var board = new Board(boardSize, mineGenerator);
        var player = new Player(initialLives);

        // Create and start the game
        var game = new Game(board, player);
        game.Start();
    }
}