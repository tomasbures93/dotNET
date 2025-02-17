using dotNET;

namespace dotNET___Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c;
            try
            {
                c = Letter('c');
            }
            catch (WrongLetterException ex) { 
                Console.WriteLine(ex.Message);
                c = 'a';
            }
            /*
            finally { }
            */
            Console.WriteLine(c);
        }

        public static char Letter(char x)
        {
            switch (x)
            {
                case 'a':
                    break;
                case 'b':
                    break;
                default:
                    throw new WrongLetterException("Falsche buchstabbel");
            }

            return x;
        }
    }
}
