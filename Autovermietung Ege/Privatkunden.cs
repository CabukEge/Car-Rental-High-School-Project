using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung
{
    class Privatkunden : Kunden
    {
        bool Mitglied;
        public Privatkunden(string Vorname2, string Zuname2, DateTime Geburtsdatum2, bool Fuehrerschein2, bool Mitglied2, bool Mieter2)
        {
            Vorname = Vorname2;
            Zuname = Zuname2;
            Geburtsname = Geburtsdatum2;
            Fuhrerschein = Fuehrerschein2;
            Mitglied = Mitglied2;
            Mieter = Mieter2;
        }
        public override string get_Firmenname()
        {
            return null;
        }
        public override bool get_Mitglied()
        {
            return Mitglied;
        }
    }
}
