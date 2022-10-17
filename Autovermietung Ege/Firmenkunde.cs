using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung
{
    class Firmenkunde : Kunden
    {
        string Firmenname;
        public Firmenkunde(string Vorname2, string Zuname2, DateTime Geburtsdatum2, bool Fuehrerschein2, string Firmenname2, bool Mieter2)
        {
            Vorname = Vorname2;
            Zuname = Zuname2;
            Geburtsname = Geburtsdatum2;
            Fuhrerschein = Fuehrerschein2;
            Firmenname = Firmenname2;
            Mieter = Mieter2;
        }

        public override string get_Firmenname()
        {
            return Firmenname;
        }
        public override bool get_Mitglied()
        {
            return false;
        }
    } 
}
