namespace LINQ___Filter_Operationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };


            // 1.Alle Zahlen echt kleiner als 7
            var kleineralssieben = from zahl in numbers
                                   where zahl < 7
                                   select zahl;
            Console.WriteLine(string.Join(',', kleineralssieben));

            var kleineralssieben2 = numbers.Where(zahl => zahl < 7);
            Console.WriteLine(string.Join(',', kleineralssieben2));

            Console.WriteLine();

            // 2.	Alle geraden Zahlen
            var allegradezahlen = from zahl in numbers
                                  where zahl % 2 == 0
                                  select zahl;
            Console.WriteLine(string.Join(',', allegradezahlen));

            var allegradezahlen2 = numbers.Where(number => number % 2 == 0);
            Console.WriteLine(string.Join(',', allegradezahlen2));

            Console.WriteLine();

            // 3.	Alle einstelligen ungeraden Zahlen
            var einstelligeungradezahlen = from zahl in numbers
                                           where zahl < 10 && zahl % 2 != 0
                                           select zahl;
            Console.WriteLine(string.Join(',', einstelligeungradezahlen));

            // Besser noch mit Math.Abs()
            var einstelligeungradezahlen2 = numbers.Where(number => number < 10 && number % 2 != 0);
            Console.WriteLine(string.Join(',', einstelligeungradezahlen2));

            Console.WriteLine();

            // 4.	Alle geraden Zahlen ab dem 6 Element (einschließlich) im Array
            var allegradezahleabsechsteelement = from zahl in numbers.Skip(5)
                                                 where zahl % 2 == 0
                                                 select zahl;
            Console.WriteLine(string.Join(',', allegradezahleabsechsteelement));

            var allegradezahleabsechsteelement2 = numbers.Skip(5).Where(number => number % 2 == 0);
            Console.WriteLine(string.Join(',', allegradezahleabsechsteelement2));

            Console.WriteLine();



            string[] numbersschreib =
                        { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
                         "nine", "ten", "eleven", "twelve", "thirteen", "fourteen" };

            // 1.Alle „Zahlen“ die drei Zeichen lang sind
            var dreibuchstabeln = numbersschreib.Where(number => number.Length == 3);
            Console.WriteLine(string.Join(',', dreibuchstabeln));

            Console.WriteLine();

            // 2.	Alle „Zahlen“ die ein „o“ enthalten
            var oenthalt = numbersschreib.Where(number => number.Contains("o"));
            Console.WriteLine(string.Join(',', oenthalt));

            Console.WriteLine();

            // 3.	Alle „Zahlen“ die auf „teen“ enden
            var endetmitteen = numbersschreib.Where(number => number.EndsWith("teen"));
            Console.WriteLine(string.Join(',', endetmitteen));

            Console.WriteLine();

            // 4.	Die Großbuchstabendarstellung aller „Zahlen“ die auf „teen“ enden
            var grosbuch = numbersschreib
                            .Where(number => number.EndsWith("teen"))
                            .Select(number => number.ToUpper());
            Console.WriteLine(string.Join(',', grosbuch));

            var grosbuch2 = from zahl in numbersschreib
                            where zahl.EndsWith("teen")
                            select zahl.ToUpper();
            Console.WriteLine(string.Join(',', grosbuch2));

            Console.WriteLine();

            // 5.	Alle „Zahlen“ die „four“ enthalten
            var fourenthalten = from zahl in numbersschreib
                                where zahl.Contains("four")
                                select zahl;
            Console.WriteLine(string.Join(',', fourenthalten));

            var fourenthalten2 = numbersschreib.Where(nummer => nummer.Contains("four"));
            Console.WriteLine(string.Join(',', fourenthalten2));

        }
    }
}
