namespace Delegates___MinMax_array
{
    delegate bool VergleichsHandandler(int x, int y);
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array erstellen und fühlen mit nummern
            Random random = new Random();   
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 50);
            }

            // Array auslesen Nummer | Index
            for(int i = 0;i < array.Length; i++)
            {
                Console.WriteLine($"Nummer: {array[i],2} | Index: {i,2}");
            }
            Console.WriteLine();

            // Zwei delegate erstellen mit funktionen
            VergleichsHandandler handlerSmall = IstKleiner;
            VergleichsHandandler handlerBig = IstGrosser;

            // Delegate aufgerufen und ausgeben lassen
            Console.WriteLine($"kleinste zahl {array[GetLimit(handlerSmall, array)]} | Index {GetLimit(handlerSmall, array)}"); 
            Console.WriteLine();
            Console.WriteLine($"Großte zahl {array[GetLimit(handlerBig, array)]} | Index {GetLimit(handlerBig, array)}");
        }

        static int GetLimit(VergleichsHandandler wasPassiert, int[] array)
        {
            int temp = array[0];
            int tempIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if(i < array.Length - 1)
                {
                    if(wasPassiert(array[i], array[i + 1]) && wasPassiert(array[i], temp))
                    {
                        temp = array[i];
                        tempIndex = i;
                    }
                } 
                else
                {
                    if(wasPassiert(array[i], temp))
                    {
                        temp = array[i];
                        tempIndex = i;
                    }
                }
            }
            return tempIndex;
        }

        static bool IstKleiner(int a, int b)
        {
            return a < b;
        }

        static bool IstGrosser(int a, int b)
        {
            return a > b;
        }
    }
}
