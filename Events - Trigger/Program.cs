using Events___Trigger.Models;

namespace Events___Trigger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            counter.CounterHigh += counter.EventCounter;

            counter.ZahlerstandErhohen(200);
            counter.Print();
            counter.ZahlerstandErhohen(200);
            counter.Print();
            counter.ZahlerstandErhohen(200);
            counter.Print();
            counter.ZahlerstandErhohen(200);
            counter.Print();
            counter.ZahlerstandErhohen(200);
            counter.Print();
            counter.ZahlerstandErhohen(200);
            Console.WriteLine();

            // ??
            Counter2 counter2 = new Counter2(
                counter => counter >= 1000,                                             // if(counter >= 1000 ) dann
                counter => Console.WriteLine($"Zählerstand erreicht: {counter}"));      // dann diese aber warum ?

            counter2.ZahlerstandErhohen(200);
            counter2.Print();
            counter2.ZahlerstandErhohen(200);
            counter2.Print();
            counter2.ZahlerstandErhohen(200);
            counter2.Print();
            counter2.ZahlerstandErhohen(200);
            counter2.Print();
            counter2.ZahlerstandErhohen(200);
            counter2.Print();
            counter2.ZahlerstandErhohen(200);
            counter2.Print();
            Console.WriteLine();

            // ????
            Counter3 counter3 = new Counter3(
                counter => counter >= 1000,
                counter => Console.WriteLine($"Johoho es macht was aber warum {counter}"));
            counter3.ZahlerstandErhohen(200);
            counter3.Print();
            counter3.ZahlerstandErhohen(200);
            counter3.Print();
            counter3.ZahlerstandErhohen(200);
            counter3.Print();
            counter3.ZahlerstandErhohen(200);
            counter3.Print();
            counter3.ZahlerstandErhohen(200);
            counter3.Print();
            counter3.ZahlerstandErhohen(200);
            counter3.Print();
            counter3.ZahlerstandErhohen(200);
            counter3.Print();
        }
    }
}
