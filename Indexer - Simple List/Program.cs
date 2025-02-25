using Indexer___Simple_List.Models;

namespace Indexer___Simple_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleList<int> list = new SimpleList<int>();
            list.AddItem(1);
            list.AddItem(2);
            list.AddItem(3);
            list.AddItem(4);
            list.AddItem(5);
            try
            {
                Console.WriteLine(list[8]);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            try
            {
                Console.WriteLine(list[2]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }
}
