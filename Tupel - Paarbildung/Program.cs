namespace Tupel___Paarbildung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 9, 42, 60, 30, 38, 7, 7, 11, 12, 13, 14, 15, 16, 17, 18 };
            Console.WriteLine("Array - ");
            foreach (int i in array)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine($"\nLength von array {array.Length} ... Mögliche paare {array.Length / 2}");
            Console.WriteLine();
            BuildTuplePairs(array);
            Console.WriteLine();
            var output = BuildTuplePairsGeneric(array);
            Console.WriteLine();
            foreach(var pair in output)
            {
                Console.WriteLine(pair);
            }
            Console.WriteLine();
            string[] stringArray = { "A", "B", "C", "D", "E" };
            BuildTuplePairsGeneric(stringArray);
        }

        //Ohne ruckgabe wert
        public static void BuildTuplePairs(int[] array)
        {
            List<(int, int)> TupleList = new List<(int, int)>();
            for(int i = 0; i < array.Length; i = i + 2)
            {
                try
                {
                    TupleList.Add((array[i], array[i + 1]));
                }
                catch (Exception e)
                {
                }
            }
            foreach( var item in TupleList)
            {
                Console.WriteLine(item);
            }
        }

        // Ruckgabewert und Generisch
        public static (T,T)[] BuildTuplePairsGeneric<T>(T[] array)
        {
            List<(T, T)> TupleList = new List<(T, T)>();
            (T,T)[] values = new (T,T)[array.Length / 2];
            int counter = 0;
            for (int i = 0; i < array.Length; i = i + 2)
            {
                try
                {
                    TupleList.Add((array[i], array[i + 1]));
                    values[counter] = (array[i], array[i + 1]);
                    counter++;
                }
                catch (Exception e)
                {
                }
            }
            foreach (var item in TupleList)
            {
                Console.WriteLine(item);
            }
            return values;
        }
    }
}
