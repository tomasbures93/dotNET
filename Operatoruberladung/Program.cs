using Operatoruberladung.Models;

namespace Operatoruberladung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ipadresse deffault = new ipadresse(192, 168, 2, 255);
            Console.WriteLine(deffault.ToString());
            deffault++;
            Console.WriteLine(deffault.ToString());
            Console.WriteLine("");
            ipadresse deffault2 = new ipadresse(192, 168, 2, 254);
            Console.WriteLine(deffault2.ToString());
            deffault2++;
            Console.WriteLine(deffault2.ToString());

            Console.WriteLine("");
            ipadresse deffault3 = new ipadresse(192, 168, 2, 255);
            Console.WriteLine(deffault3.ToString());
            deffault3++;
            Console.WriteLine(deffault3.ToString());
            deffault3++;
            Console.WriteLine(deffault3.ToString());

            Console.WriteLine("");
            ipadresse deffault4 = new ipadresse(192, 168, 255, 255);
            Console.WriteLine(deffault4.ToString());
            deffault4++;
            Console.WriteLine(deffault4.ToString());
            deffault4++;
            Console.WriteLine(deffault4.ToString());
            deffault4++;
            Console.WriteLine(deffault4.ToString());

            Console.WriteLine("");
            ipadresse deffault5 = new ipadresse(192, 255, 255, 255);
            Console.WriteLine(deffault5.ToString());
            deffault5++;
            Console.WriteLine(deffault5.ToString());
            deffault5++;
            Console.WriteLine(deffault5.ToString());
            deffault5++;
            Console.WriteLine(deffault5.ToString());

            Console.WriteLine("");
            ipadresse deffault6 = new ipadresse(254, 255, 255, 255);
            Console.WriteLine(deffault6.ToString());
            deffault6++;
            Console.WriteLine(deffault6.ToString());
            deffault6++;
            Console.WriteLine(deffault6.ToString());

            Console.WriteLine("");
            ipadresse deffault7 = new ipadresse(255, 255, 255, 255);
            Console.WriteLine(deffault7.ToString());
            deffault7++;
            Console.WriteLine(deffault7.ToString());
            deffault7++;
            Console.WriteLine(deffault7.ToString());

            Console.WriteLine("");
            ipadresse deffault8 = new ipadresse(10, 11, 255, 11);
            deffault8++;
            Console.WriteLine(deffault8.ToString());

            ipadresse eine = new ipadresse(10,10,10,10);
            ipadresse zwei = new ipadresse(10,10,10,10);

            Console.WriteLine($"{eine.ToString()} == {zwei.ToString()} - {eine == zwei}");
            Console.WriteLine($"{eine.ToString()} != {zwei.ToString()} - {eine != zwei}");
            Console.WriteLine($"{eine.ToString()} > {zwei.ToString()} - {eine > zwei}");
            Console.WriteLine($"{eine.ToString()} < {zwei.ToString()} - {eine < zwei}");

            Console.WriteLine(ipadresse.InsertIP("192.168.X.18"));
            Console.WriteLine(ipadresse.InsertIP("192.168.12.18"));

            Console.WriteLine(ipadresse.InsertIP("hohoho"));


            // Chatbot 

            IPv4Address ip1 = IPv4Address.Parse("192.168.1.1");
            IPv4Address ip2 = IPv4Address.Parse("192.168.2.5");

            Console.WriteLine("Zwischen liegende IP-Adressen:");
            foreach (var ip in IPv4Address.GetAddressesInRange(ip1, ip2))
            {
                Console.WriteLine(ip);
            }

        }
        

    }
}
