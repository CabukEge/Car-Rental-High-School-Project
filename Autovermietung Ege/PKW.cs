using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung
{
    class PKW : Fahrzeug
    {
        bool Automatik;
        bool Klimaanlage;
        int Sitzplätze;
        public PKW(double Grundpreis2, double Mietpreis_pro_km2, long KmStand2, string Fahrzeugtyp2, bool Automatik2, bool Klimaanlage2, int Sitzplätze2, bool Vermietet2)
        {
            Grundpreis = Grundpreis2;
            Mietpreis_pro_km = Mietpreis_pro_km2;
            KmStand = KmStand2;
            Fahrzeugtyp = Fahrzeugtyp2;
            Automatik = Automatik2;
            Klimaanlage = Klimaanlage2;
            Sitzplätze = Sitzplätze2;
            Vermietet = Vermietet2;
        }
        public override bool get_Automatik()
        {
            return Automatik;
        }
        public override bool get_Klimaanlage()
        {
            return Klimaanlage;
        }
        public override int get_Sitzplatze()
        {
            return Sitzplätze;
        }
        public override double get_Ladefläche()
        {
            return 0.0;
        }
        public override double get_Ladevolumen()
        {
            return 0.0;
        }
        public override double get_Zugewicht()
        {
            return 0.0;
        }

    }
}
