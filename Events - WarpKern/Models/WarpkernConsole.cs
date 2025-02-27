using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Events___WarpKern.Models
{
    internal class WarpkernConsole 
    {

        public WarpkernConsole(WarpKern warpKern) {
            warpKern.TempEvent += CheckEventTemp;
            warpKern.TempEventFuckedup += Explosion;
        }
        public void CheckEventTemp(object sender, TemperaturEventArgs e)
        {
            double temp = ((WarpKern)sender).WarpKernTemperatur;
            if(temp > 0 && temp < 250)
            {
                Console.WriteLine("***** CONSOLE");
                Console.WriteLine($"{e.Zeitstempel} - {temp}°C");
                Console.WriteLine($"Temperatur OK");
                Console.WriteLine("Temp OK - Press Enter to continue");
            } 
            else if( temp >= 250 && temp < 500)
            {
                Console.WriteLine("***** CONSOLE");
                Console.WriteLine($"{e.Zeitstempel} - {temp}°C");
                Console.WriteLine($"Temperatur too HIGH");
                Console.WriteLine("Temp OK - Press Enter to continue");
            }
        }

        public void Explosion(object sender, TemperaturEventArgs e)
        {
            Console.WriteLine("***** CONSOLE");
            Console.WriteLine(" YOU ARE FUCKED UP ");
            Console.WriteLine($"{e.Zeitstempel} - {((WarpKern)sender).WarpKernTemperatur}°C");
            Console.WriteLine(" RUN FOREST RUN ");
            Task.Delay(3000).Wait();
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
                Task.Delay(1000).Wait();
            }
            Console.WriteLine("BOOM");
            Environment.Exit(0);
        }
    }
}
