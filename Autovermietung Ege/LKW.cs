using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung
{
    class LKW : Fahrzeug
    {
        double Ladefläche;
        double Ladevolumen;
        double ZuladungGesamtgewicht;
        public LKW(double Grundpreis2, double Mietpreis_pro_km2, long KmStand2, string Fahrzeugtyp2, double Ladefläche2, double Ladevolumen2, double ZuladungGesamtgewicht2, bool Vermietet2)
        {
            Grundpreis = Grundpreis2;
            Mietpreis_pro_km = Mietpreis_pro_km2;
            KmStand = KmStand2;
            Fahrzeugtyp = Fahrzeugtyp2;
            Ladefläche = Ladefläche2;
            Ladevolumen = Ladevolumen2;
            ZuladungGesamtgewicht = ZuladungGesamtgewicht2;
            Vermietet = Vermietet2;
        }
        public override bool get_Automatik()
        {
            return false;
        }
        public override bool get_Klimaanlage()
        {
            return false;
        }
        public override int get_Sitzplatze()
        {
            return 2;
        }
        public override double get_Ladefläche()
        {
            return Ladefläche;
        }
        public override double get_Ladevolumen()
        {
            return Ladevolumen;
        }
        public override double get_Zugewicht()
        {
            return ZuladungGesamtgewicht;
        }
    }
}
