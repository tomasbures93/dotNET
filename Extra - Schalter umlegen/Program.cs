namespace Extra___Schalter_umlegen
{
    internal class Program
    {
        static bool[,] feld = new bool[10, 10];
        static int leute = 100;

        static void Main(string[] args)
        {
            MakeArray();
            TouchLED();
        }
        static void TouchLED()
        {
            int person = 1;
            do
            {
                Console.Clear();
                Console.WriteLine($"LEDs for Simulation. Person {person}");
                PressSwitch(person);
                ShowArray();
                person++;
                Task.Delay(1000).Wait();
            } while (person <= leute);
            Console.WriteLine();
            Console.WriteLine("All People pressed the Switch!");
        }

        static void PressSwitch(int person)
        {
            int internalCount = 1;
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                for (int j = 0; j < feld.GetLength(1); j++)
                {
                    if(internalCount == person)
                    {
                        feld[i,j] = feld[i, j] ? false : true;
                        internalCount = 0;
                    }
                    internalCount++;
                }
            }
        }

        static void ShowArray()
        {
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                for (int j = 0; j < feld.GetLength(1); j++)
                {
                    if(feld[i, j] == false)
                    {
                        Console.Write($"|   ");
                    } else
                    {
                        Console.Write("|");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write($"   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (j == feld.GetLength(1) - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine("\n+---+---+---+---+---+---+---+---+---+---+");
            }
        }

        static void MakeArray()
        {
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                for (int j = 0; j < feld.GetLength(1); j++)
                {
                    feld[i, j] = false;
                }
            }
        }
    }
}
