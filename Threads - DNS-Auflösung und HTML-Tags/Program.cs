using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Threads___DNS_Auflösung_und_HTML_Tags
{
    internal class Program
    {
        static string path = @"C:\Users\ITA7-TN01\Desktop\websiten.txt";
        static List<string> websites = new List<string>();
        static List<string> urls = new List<string>();
        static void Main(string[] args)
        {
            LoadFile();

            foreach (string site in websites)
            {
                Task<string> task = Task<string>.Run(() =>
                {
                    //Console.Write($"Task ID {Task.CurrentId,3} gestarted | ");
                    string output = site;
                    IPHostEntry host = Dns.GetHostEntry(site);
                    output = "Website: \t" + output + "\nIP: \t\t";
                    foreach (IPAddress ip in host.AddressList)
                    {
                        output = output + ip.ToString() + ", ";
                    }
                    return output;
                }).ContinueWith(taskBefore => 
                    {
                        try
                        {
                            WebClient client = new WebClient();
                            string html = client.DownloadString("https://" + site);
                            string text = taskBefore.Result + "\nHTML length: \t" + html.Length + " characters";
                            //Console.Write($"Task ID {Task.CurrentId - 1,3} completed \n");
                            return text;
                         }
                        catch (Exception ex)
                        {
                            string text = taskBefore.Result + "\n" + "Fehler:\t\t" + ex.Message;
                            //Console.WriteLine($"Task ID {Task.CurrentId - 1,3} completed");
                            return text;
                        }
                    });
                urls.Add(task.Result);
            }

            Task.WaitAll();

            foreach (string site in urls)
            {
                Console.WriteLine();
                Console.WriteLine(site);
            }

            Console.ReadKey();
        }

        private static void LoadFile()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    websites.Add(line.Trim());
                }
            }
        }
    }
}
