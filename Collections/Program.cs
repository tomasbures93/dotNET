namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pfad = @"C:\Users\ITA7-TN01\Desktop\abc.txt";
            List<string> inhalt = new List<string>();

            FileStream stream = new FileStream(pfad, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(stream);

            while(sr.Peek() >= 0)
            {
                inhalt.Add(sr.ReadLine());
            }
            sr.Close();
            inhalt.Reverse();
            foreach (string s in inhalt)
            {
                Console.WriteLine(s);
            }


            Console.ReadKey();
            Console.WriteLine("Bitte geben sie mathematischen Ausdruck ein");
            string input = Console.ReadLine();
            Console.WriteLine(IstEsOk(input));
        }

        public static bool IstEsOk(string ausdruck)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in ausdruck)
            {
                if(c == '(')
                {
                    stack.Push(c);
                } else if (c == ')') { 
                    if(stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
    }
}
