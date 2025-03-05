namespace Tupel___Reißverschluss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 21, 65, 6, 1, 14, 58, 56, 38, 18, 2, 4, 6, 8 };
            int[] array2 = { 95, 1, 86, 32, 66, 27, 67, 10, 54, 55, 8, 12, 13, 14 };
            string[] stringArray = { "A", "B", "C", "D", "E" };
            string[] stringArray2 = { "R", "T", "Q", "G", "H", "K" };
            BuildPairs(array1, array2);
            Console.WriteLine();
            BuildPairsGenerish(stringArray2, stringArray);
            Console.WriteLine();
            BuildPairsGenerish(array1, stringArray);
            Console.WriteLine();
            var output = BuildPairsGenerish(array2, stringArray2);
            Console.WriteLine();
            foreach (var pair in output)
            {
                Console.WriteLine(pair);
            }
        }

        //Ohne ruckgabe wert
        public static void BuildPairs(int[] array1, int[] array2)
        {
            List<(int, int)> tupleList = new List<(int, int)> ();
            int length = (array1.Length <= array2.Length) ? array1.Length : array2.Length;
            for (int i = 0; i < length; i++)
            {
                tupleList.Add((array1[i], array2[i]));
            }
            foreach(var tuple in tupleList)
            {
                Console.WriteLine(tuple);
            }
        }

        // Ruckgabewert und Generisch
        public static (T1 ,T2)[] BuildPairsGenerish<T1, T2>(T1[] input1, T2[] input2)
        {
            List<(T1, T2)> tupleList = new List<(T1, T2)> (); 
            int length = (input1.Length <= input2.Length) ? input1.Length : input2.Length;
            (T1, T2)[] values = new (T1, T2)[length];
            for (int i = 0; i < length; i++) {
                tupleList.Add((input1[i], input2[i]));
                values[i] = (input1[i], input2[i]);
            }
            foreach (var tuple in tupleList)
            {
                Console.WriteLine(tuple);
            }
            return values;
        }
    }
}
