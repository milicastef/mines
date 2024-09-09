namespace Minesweeper.Models
{
    public class MineGenerator
    {
        private readonly Random _random;

        public MineGenerator()
        {
            _random = new Random();
        }

        public bool[,] GenerateMines(int size)
        {
            var mines = new bool[size, size];
            int mineCount = size; // Arbitrary mine count, can be configured

            for (int i = 0; i < mineCount; i++)
            {
                int row, col;
                do
                {
                    row = _random.Next(size);
                    col = _random.Next(size);
                } while (mines[row, col]);

                mines[row, col] = true;
            }

            return mines;
        }
    }
}
