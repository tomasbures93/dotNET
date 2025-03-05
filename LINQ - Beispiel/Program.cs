namespace LINQ___Beispiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] namen = { "Anna", "Anne", "Emma", "Erich", "Olaf", "Xaver", "Xhantippe" };


            // version 1 - Deklarative form
            var all_even = from zahl in array
                           where zahl % 2 == 0
                           select zahl;

            Console.WriteLine(String.Join(",", all_even));

            var namen_gruppiertnach_lange = from name in namen
                                            group name by name.Length 
                                            into namen_gruppe
                                            select new { Lange = namen_gruppe.Key, Namen = namen_gruppe };
            Console.WriteLine();
            foreach(var g in namen_gruppiertnach_lange)
            {
                Console.WriteLine("Namen der Lange: " + g.Lange);
                Console.WriteLine(string.Join(",", g.Namen));
            }

            Console.WriteLine();

            var namen_gruppiertnach_lange2 = from name in namen
                                            group name by new { anfagn = name[0], Lange = name.Length } 
                                            into namen_gruppe
                                            select new { Lange = namen_gruppe.Key, Namen = namen_gruppe };
            foreach (var g in namen_gruppiertnach_lange2)
            {
                Console.WriteLine("Namen der Lange: " + g.Lange);
                Console.WriteLine(string.Join(",", g.Namen));
            }

            Console.WriteLine();
            // version 2 - Imperative form
            var all_even2 = array.Where(zahl => zahl % 2 == 0);
            Console.WriteLine(String.Join(",", all_even2));

        }
    }
}
