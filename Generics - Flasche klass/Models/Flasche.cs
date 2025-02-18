using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche_klass.Models
{
    class Flasche<T> where T : IGetraenk                // <T> - wir haben gesagt es ist eine Generische klasse, und ich kann da nur einsetzen Klassen welche implementieren IGetraenk
    {
        private T _inhalt;                              // daten typ T ( wir wissen noch nicht was das ist )

        public T Inhalt 
        { 
            get { return _inhalt; } 
            private set {  _inhalt = value; } 
        }

        public void Fuellen(T getreank)
        {
            Inhalt = getreank;
        }

        public string IstLeer()                                                 // IST - sollte bool wert zurück geben
        {
            return object.Equals(Inhalt, default(T))?"Leer":"Voll";             // vergleichen ob Inhalt ist leer oder nicht
        }  
        
        public T Leeren()
        {
            T puffer = Inhalt;
            Inhalt = default;                                   // Übernimmt der default datentyp wert von Inhalt
            return puffer;
        }

        public void Ausgabe()
        {
            Inhalt.Ausgabe();
        }
    }
}
