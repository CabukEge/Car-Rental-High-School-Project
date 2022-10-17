using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung
{
    abstract class Kunden
    {
        protected string Vorname;
        protected string Zuname;
        protected DateTime Geburtsname;
        protected bool Fuhrerschein;
        protected bool Mieter;

        public string get_Vorname()
        {
            return Vorname;
        }
        public string get_Zuname()
        {
            return Zuname;
        }
        public DateTime get_Gebi()
        {
            return Geburtsname;
        }
        public bool get_Fuhrerschein()
        {
            return Fuhrerschein;
        }
        public bool get_Mieter()
        {
            return Mieter;
        }
        public void set_Mieter(bool b)
        {
            Mieter = b;
        }
        public abstract string get_Firmenname();
        public abstract bool get_Mitglied();
    }
    
}
