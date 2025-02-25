using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoruberladung.Models
{

    // CHATGPT lösung / Bit verschiebung
    public class IPv4Address
    {
        private uint address;


        // byte -> 0-255
        // Konstruktor mit vier Oktetten
        public IPv4Address(byte octet1, byte octet2, byte octet3, byte octet4)
        {
            address = ((uint)octet1 << 24) | ((uint)octet2 << 16) | ((uint)octet3 << 8) | octet4;
        }

        /* 
            Warum wird die IP als uint gespeichert?
            Vorteil 1: Effizienz – Die gesamte IP-Adresse wird in nur einem Wert gespeichert (statt in vier separaten byte-Variablen).
            Vorteil 2: Vergleich & Sortierung – Da uint numerisch ist, kann eine IP direkt mit <, > verglichen oder sortiert werden.
            Vorteil 3: Speicherplatz – uint benötigt 4 Bytes, was genau der Länge einer IPv4-Adresse entspricht.

            192  -> 11000000 (Binär)
            168  -> 10101000 (Binär)
            1    -> 00000001 (Binär)
            1    -> 00000001 (Binär)

            11000000 10101000 00000001 00000001  (entspricht 3232235777 in Dezimal)
         */

        // Konstruktor mit uint-Adresse
        private IPv4Address(uint address)
        {
            this.address = address;
        }

        // Statische Methode zur Umwandlung eines Strings in eine IPv4-Adresse
        public static IPv4Address Parse(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString))
                throw new ArgumentException("Die IP-Adresse darf nicht leer oder null sein.");

            string[] parts = ipString.Split('.');
            if (parts.Length != 4)
                throw new FormatException("Ungültige IP-Adresse: " + ipString);

            if (byte.TryParse(parts[0], out byte o1) &&
                byte.TryParse(parts[1], out byte o2) &&
                byte.TryParse(parts[2], out byte o3) &&
                byte.TryParse(parts[3], out byte o4))
            {
                return new IPv4Address(o1, o2, o3, o4);
            }
            else
            {
                throw new FormatException("Ungültige IP-Adresse: " + ipString);
            }
        }

        // Überladung von ToString()
        public override string ToString()
        {
            return $"{(address >> 24) & 0xFF}.{(address >> 16) & 0xFF}.{(address >> 8) & 0xFF}.{address & 0xFF}";
        }
        /*
                Warum wird >> (Bitweise Verschiebung) verwendet?
                Der Operator >> (Bitshift nach rechts) wird genutzt, um die einzelnen Oktette der IPv4-Adresse aus der uint-Speicherung zu extrahieren.
                Da die IP-Adresse als uint (32-Bit) gespeichert ist, müssen wir sie zurück in 4 Oktette umwandeln.

                Oktett 1 (192): Liegt ganz links (höchste 8 Bit).
                    ➝ Muss um 24 Stellen nach rechts verschoben werden (>> 24).
                Oktett 2 (168): Liegt auf den nächsten 8 Bit.
                    ➝ Muss um 16 Stellen nach rechts verschoben werden (>> 16).
                Oktett 3 (1): Liegt auf den nächsten 8 Bit.
                    ➝ Muss um 8 Stellen nach rechts verschoben werden (>> 8).
                Oktett 4 (1): Liegt ganz rechts (niedrigste 8 Bit).
                    ➝ Keine Verschiebung nötig.

                Warum & 0xFF?
                Die Bitmaske 0xFF (= 255 in Dezimal, 11111111 in Binär) sorgt dafür, dass wir nur die letzten 8 Bit des Ergebnisses erhalten.

                💡 Warum ist das nötig?
                Nach der Bitverschiebung können noch andere Bits vorhanden sein. Das & 0xFF sorgt dafür, dass wir nur das relevante Oktett behalten.

         */

        // Inkrement-Operator ++
        public static IPv4Address operator ++(IPv4Address ip)
        {
            if (ip.address == 0xFFFFFFFF)
                throw new InvalidOperationException("IP-Adresse kann nicht weiter inkrementiert werden.");
            return new IPv4Address(ip.address + 1);
        }

        // Vergleichsoperatoren
        public static bool operator <(IPv4Address a, IPv4Address b) => a.address < b.address;
        public static bool operator >(IPv4Address a, IPv4Address b) => a.address > b.address;
        public static bool operator ==(IPv4Address a, IPv4Address b) => a.address == b.address;
        public static bool operator !=(IPv4Address a, IPv4Address b) => a.address != b.address;

        public override bool Equals(object obj)
        {
            return obj is IPv4Address ip && this == ip;
        }

        public override int GetHashCode()
        {
            return address.GetHashCode();
        }

        // Methode zum Ausgeben aller IP-Adressen zwischen zwei Adressen
        public static List<IPv4Address> GetAddressesInRange(IPv4Address start, IPv4Address end)
        {
            if (start > end)
                throw new ArgumentException("Die Start-IP muss kleiner oder gleich der End-IP sein.");

            List<IPv4Address> addresses = new List<IPv4Address>();
            for (IPv4Address ip = start; ip < end; ip++)
            {
                addresses.Add(ip);
            }
            addresses.Add(end);
            return addresses;
        }
    }
}
