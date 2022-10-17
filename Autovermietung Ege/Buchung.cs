using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung
{
    class Buchung
    {
        char Status, Fahrzeugtyp, Kundenart;
        int Fahrzeugnummer, Kundennummer;
        
        public Buchung(char Status2, char Fahrzeugtyp2, char Kundenart2, int Fahrzeugnummer2, int Kundennummer2)
        {
            Status = Status2;
            Fahrzeugtyp = Fahrzeugtyp2;
            Kundenart = Kundenart2;
            Fahrzeugnummer = Fahrzeugnummer2;
            Kundennummer = Kundennummer2;
        }
        public char get_Status()
        {
            return Status;
        }
        public void set_Status(char c)
        {
            Status = c;
        }
        public char get_Fahrzeugtyp()
        {
            return Fahrzeugtyp;
        }
        public char get_Kundenart()
        {
            return Kundenart;
        }
        public int get_Fahrzeugnummer()
        {
            return Fahrzeugnummer;
        }
        public int get_Kundennummer()
        {
            return Kundennummer;
        }
        
    }
}
