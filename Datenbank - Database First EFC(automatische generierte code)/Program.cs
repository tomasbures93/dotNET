using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Datenbank___Database_First_EFC_automatische_generierte_code_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderDbContext context = new OrderDbContext();

            // Alle Kunden werden nach Nachnamen alphabetisch sortiert ausgegeben
            foreach (
                var kunde in context.Customers.Where(k => k.Country == "Germany")
                                                .OrderBy(n => n.LastName)
                                                .ThenBy(n => n.FirstName))
            {
                Console.WriteLine(kunde.LastName + " " + kunde.FirstName);
            }

            Console.WriteLine();

            // Es wird der Gesamtwert aller Bestellungen eines Kunden ausgegeben


            var kundebestellung = context.Customers.Include(o => o.Orders)
                                                   .Where(k => k.Country == "Germany")
                                                   .OrderBy(n => n.LastName)
                                                   .ToList();
            foreach (var k in kundebestellung)
            {
                var ingesamt = k.Orders.Sum(s => s.TotalAmount);
                Console.WriteLine($"{k.FirstName} {k.LastName} - {ingesamt} Euro");

            }

            Console.WriteLine();



            // Zu jeder einzelnen Bestellung wird die Bestellnummer, das Bestelldatum und der 
            // Bestellwert der einzelnen Bestellung ausgegeben

            var kundeInfoUndBestellung = context.Customers.Join(context.Orders,
                                                                customer => customer.Id,
                                                                order => order.Id,
                                                                (customer, order) => new { C = customer, O = order });



            //var orderitemjoin = context.Customers.Join(context.Orders,
            //                                                    customer => customer.Id,
            //                                                    order => order.CustomerId,
            //                                                    (customer, order) => new { C = customer, O = order })
            //                                    .Join(context.OrderItems,
            //                                                    order => order.O.Id,
            //                                                    orderI => orderI.OrderId,
            //                                                    (order, orderI) => new { O = order, OI = orderI })
            //                                    .Join(context.Products,
            //                                                    orderI => orderI.OI.ProductId,
            //                                                    prod => prod.Id,
            //                                                    (orderI, prod) => new { OI = orderI, p = prod });

            //foreach (var t in orderitemjoin)
            //{
            //    Console.WriteLine(t.p.ProductName);
            //}


            var test = context.Customers.Where(k => k.Country == "Germany" && k.Orders.Count > 0)
                    .Select(kunde =>
                        new
                        {
                            FirstName = kunde.FirstName,
                            LastName = kunde.LastName,
                            Total = kunde.Orders.Any() ? kunde.Orders.Sum(s => s.TotalAmount) : 0,
                            Bestelung = kunde.Orders.SelectMany(p => p.OrderItems),
                            ProduktInfo = kunde.Orders.SelectMany(p => p.OrderItems.Select(pp => pp.Product))
                        }
                    ).OrderBy(n => n.LastName);

            foreach(var k in test)
            {
                Console.WriteLine();
                Console.WriteLine("Kunde: " + k.FirstName + " " + k.LastName);
                Console.WriteLine("Gesamter Bestellwert: " + k.Total + " Euro");
                Console.WriteLine("Bestellungen: ");
                foreach(var b in k.Bestelung)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nr.: " + b.Order.OrderNumber + " Datum: " + b.Order.OrderDate + " Bestellwert " + b.UnitPrice * b.Quantity);
                    Console.Write("Artikel: ");
                    foreach (var p in k.ProduktInfo.Where(p => p.Id == b.ProductId))
                    {
                        Console.Write(p.ProductName + ", ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
