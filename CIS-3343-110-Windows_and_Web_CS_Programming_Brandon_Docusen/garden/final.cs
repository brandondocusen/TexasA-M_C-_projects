using System;

class RabbitGarden
{
    private static Tuple<int, int> FindCenter(int[,] garden)
    {
        int rows = garden.GetLength(0);
        int cols = garden.GetLength(1);
        Tuple<int, int> center = Tuple.Create(rows / 2, cols / 2);

        int maxCarrots = 0;
        Tuple<int, int> maxPosition = center;

        int startRow = rows % 2 == 0 ? center.Item1 - 1 : center.Item1;
        int startCol = cols % 2 == 0 ? center.Item2 - 1 : center.Item2;
        
        for (int i = startRow; i <= center.Item1; i++)
        {
            for (int j = startCol; j <= center.Item2; j++)
            {
                Console.WriteLine("Checking square ({0},{1}) with {2} carrots.", i, j, garden[i, j]);
                if (garden[i, j] > maxCarrots)
                {
                    maxCarrots = garden[i, j];
                    maxPosition = Tuple.Create(i, j);
                }
            }
        }
        Console.WriteLine("Starting at square ({0},{1}) with {2} carrots.", maxPosition.Item1, maxPosition.Item2, maxCarrots);
        return maxPosition;
    }

    private static int EatCarrots(int[,] garden)
    {
        int totalCarrots = 0;
        Tuple<int, int> position = FindCenter(garden);
        int row = position.Item1;
        int col = position.Item2;

        while (true)
        {
            totalCarrots += garden[row, col];
            Console.WriteLine("Eating {0} carrots at ({1},{2})", garden[row, col], row, col);
            garden[row, col] = 0;

            Tuple<int, int> nextMove = FindNextMove(garden, row, col);
            if (nextMove == null)
            {
                break;
            }
            row = nextMove.Item1;
            col = nextMove.Item2;
        }

        return totalCarrots;
    }

    private static Tuple<int, int> FindNextMove(int[,] garden, int currentRow, int currentCol)
    {
        int rows = garden.GetLength(0);
        int cols = garden.GetLength(1);
        int maxCarrots = 0;
        Tuple<int, int> nextMove = null;

        int[] dRow = { -1, 0, 1, 0 };
        int[] dCol = { 0, 1, 0, -1 };

        for (int direction = 0; direction < 4; direction++)
        {
            int newRow = currentRow + dRow[direction];
            int newCol = currentCol + dCol[direction];

            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
            {
                Console.WriteLine("Checking square ({0},{1}) with {2} carrots.", newRow, newCol, garden[newRow, newCol]);
                if (garden[newRow, newCol] > maxCarrots)
                {
                    maxCarrots = garden[newRow, newCol];
                    nextMove = Tuple.Create(newRow, newCol);
                }
            }
        }
        if (nextMove != null)
        {
            Console.WriteLine("Next move to square ({0},{1}) with {2} carrots.", nextMove.Item1, nextMove.Item2, maxCarrots);
        }
        else
        {
            Console.WriteLine("No more moves available, rabbit goes to sleep.");
        }
        return nextMove;
    }
    static void Main()
    {
        int[,] garden = {
            {10, 15, 9, 7, 6, 4, 3, 2, 1, 12},
            {12, 2, 3, 4, 1, 6, 7, 8, 10, 0},
            {0, 1, 7, 6, 2, 5, 3, 6, 0, 23},
            {4, 9, 0, 5, 12, 14, 2, 4, 4, 2},
            {22, 21, 6, 1, 16, 2, 5, 5, 0, 6},
            {9, 8, 5, 3, 7, 6, 12, 6, 12, 3},
            {10, 2, 0, 6, 8, 9, 14, 22, 13, 15},
            {9, 6, 5, 4, 1, 10, 12, 10, 2, 1}
        };

        int result = EatCarrots(garden);
        Console.WriteLine("The rabbit ate {0} carrots.", result);

        Console.WriteLine("Press any key to close the program.");
        Console.ReadKey();
    }
}