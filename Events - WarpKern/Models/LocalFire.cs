using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___WarpKern.Models
{
    internal class LocalFire
    {
        public LocalFire(WarpKern warpKern)
        {
        }
        public void CheckEventTemp(object sender, TemperaturEventArgs e)
        {
            double temp = ((WarpKern)sender).WarpKernTemperatur;
            if (temp > 0 && temp < 500)
            {
                Console.WriteLine("***** FEUERWE...");
                Console.WriteLine($"{e.Zeitstempel} - {temp}°C");
                Console.WriteLine($"Temperatur OK - Wir müssen nicht los");
            }
        }

        public void Explosion(object sender, TemperaturEventArgs e)
        {
            Console.WriteLine("***** FEUERWE...");
            Console.WriteLine(" We have to clear the place explosion is coming soon ");
            Console.WriteLine($"{e.Zeitstempel} - {((WarpKern)sender).WarpKernTemperatur}°C");
        }
    }
}
