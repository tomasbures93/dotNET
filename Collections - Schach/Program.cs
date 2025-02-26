using System;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Collections___Schach
{
    internal class Program
    {
        static Pferd horst = new Pferd();
        static Random random = new Random();
        static void Main(string[] args)
        {
            // 8 x 8 feld
            string[,] felder = new string[8,8];

            // array fühlen
            for (int i = 0; i < felder.GetLength(0); i++)
            {
                for (int j = 0; j < felder.GetLength(1); j++)
                {
                    felder[i, j] = "0";
                }
            }

            int counter = 0;
            while( counter < 64 )
            {
                Console.Clear();
                var (nextX, nextY) = FindBestMove(felder, horst.X, horst.Y);
                
                horst.X = nextX;
                horst.Y = nextY;
                horst.AddInZuge($"{nextX}{nextY}", $"{nextY}{nextX}");

                counter++;
                Draw(counter, felder);
                Task.Delay(300).Wait();
            }
        }

        public static (int, int) FindBestMove(string[,] array, int x, int y)
        {
            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

            List<(int x, int y, int moves)> moving= new List<(int, int, int)>();
            for (int i = 0; i < 8; i++)
            {
                int nx = horst.X + dx[i];
                int ny = horst.Y + dy[i];
                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8 && array[nx, ny] == "0")
                {
                    int howoften = PossibleMoves(array, nx, ny);
                    moving.Add((nx, ny, howoften));
                }
            }
            if (moving.Count == 0) return (-1, -1);

            moving.Sort((a,b) => a.moves.CompareTo(b.moves));
            int minMoves = moving[0].moves;
            var bestMoves = moving.FindAll(m => m.moves == minMoves);
            var chosenMove = bestMoves[random.Next(bestMoves.Count)];

            return (chosenMove.x, chosenMove.y);
        }
        public static int PossibleMoves(string[,] array, int x, int y)
        {
            int countermoves = 0;
            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
            for (int i = 0; i < 8; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8 && array[nx, ny] == "0")
                {
                    countermoves++;
                }
            }
            return countermoves;
        }

        public static void Draw(int counter, string[,] array)
        {
            Console.WriteLine($"{counter}");
            Console.WriteLine("\n\n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine("\t     ---------------------------------------------------------");
                Console.Write("\t " + (i) + "   | ");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (horst.X == i && horst.Y == j)
                    {
                        array[i, j] = counter.ToString();
                    }
                    Console.Write($" {array[i, j],2}  | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t     ---------------------------------------------------------");
            Console.WriteLine("\t         0      1      2      3      4      5      6      7");
        }
    }
}
