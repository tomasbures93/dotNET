using Delegates___Groß_klein.Models;

namespace Delegates___Groß_klein
{
    // delegate deklariert mit parameter string und return typ void
    delegate void CharacterHandler(string text);
    delegate void CharacterHandlerMulticast(string text);
    delegate void CharacterAnonymHandler(string text);

    // delegate deklariert mit parameter string und return typ int
    delegate int CharacterCountHandler(string text);
    internal class Program
    {
        static void Main(string[] args)
        {
            // SINGLE DELEGATE

            // delegate instanziirt
            CharacterHandler changetext;
            // funktion hinzugefügt in delegate
            changetext = Character.UpperLower;
            // delegate benutzt ( ruft die funktion an )
            changetext("Ich bin ein delegate");
            Console.WriteLine($"Methode: {changetext.Method} | Methode Name: {changetext.Method.Name}");           // was für funktion ich habe benutzt

            Console.WriteLine();
            CharacterHandler changetext2 = Character.UpperCase;         // instanziirt udn direkt hunzugefügt
            changetext2("Hallo ich bin auch ein delegate"); 
            Console.WriteLine($"Methode: {changetext2.Method} | Methode Name: {changetext2.Method.Name}");

            Console.WriteLine();
            CharacterHandler changetext3 = Character.LowerCase;
            changetext3("Ich bin auch ein delegate!");
            Console.WriteLine($"Methode: {changetext3.Method} | Methode Name: {changetext3.Method.Name}");

            Console.WriteLine();
            CharacterCountHandler textcount = Character.Characters;
            Console.WriteLine($"Hallo, wie lange bin ich - ist {textcount("Hallo, wie lange bin ich")} characters long");
            Console.WriteLine($"Methode {textcount.Method} | Methode Name: {textcount.Method.Name}");

            Console.WriteLine();
            // MULTICAST DELEGATE
            CharacterHandlerMulticast multitext;
            multitext = Character.UpperLower;
            multitext += Character.LowerCase;                                           // AUFPASSEN! = überschreibt ... += addiert die methode
            multitext += Character.UpperCase;
            multitext("Hallo ich bin ein multi delegat!");                              // Gibt drei aus weil dir funktionen printen CW
            Console.WriteLine($"Methode: {multitext.Method} | Methode Name: {multitext.Method.Name}");                        // Warum upperCase ? Weil die habe ich als letzte hinzugefügt

            Console.WriteLine();
            Delegate[] list = multitext.GetInvocationList();                            // Returns a list of Delegates gespeichert in multitext Delegate
            Console.WriteLine($"Ich habe {list.Length} delegate in meine Liste");
            foreach (Delegate item in list)
            {
                // Was für methoden habe ich in meine Liste von MULTICAST
                Console.WriteLine($"Methode: {item.Method} | Methode Name: {item.Method.Name} | Target: {item.Target ?? "null"}");
            }

            // Anonyme Delegate
            Console.WriteLine();
            CharacterAnonymHandler anonymtext = delegate (string text)          // DELEGATE ERSTELLEN ... direkte funktion schreiben!
            {
                Console.WriteLine(text.ToUpper());
            };                                                                  // ; - semikolon ist wichtig!!!

            anonymtext("test");                                                 // Anonyme delegate aufrufen ... er ruft die versteckte funktion da hinter ( die funktion hat keine name, nur logic )
            Console.WriteLine($"Methode: {anonymtext.Method} | Methode Name: {anonymtext.Method.Name} | Target: {anonymtext.Target}");               // Method von anonyme Delegate
        }
    }
}
