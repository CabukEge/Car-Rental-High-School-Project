using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung
{
    abstract class Fahrzeug
    {

        protected double Grundpreis;
        protected double Mietpreis_pro_km;
        protected long KmStand;
        protected string Fahrzeugtyp;
        protected bool Vermietet;
        public string get_Fahrzeugtyp()
        {
            return Fahrzeugtyp;
        }
        public double get_Grundpreis()
        {
            return Grundpreis;
        }
        public long get_KmStand()
        {
            return KmStand;
        }
        public double get_Mietpreis()
        {
            return Mietpreis_pro_km;
        }
        public bool get_Vermietet()
        {
            return Vermietet;
        }
        public void set_Vermietet(bool b)
        {
            Vermietet = b;
        }
        public abstract bool get_Klimaanlage();
        public abstract bool get_Automatik();
        public abstract int get_Sitzplatze();
        public abstract double get_Ladevolumen();
        public abstract double get_Ladefläche();
        public abstract double get_Zugewicht();
        public bool set_KmStand(long l)
        {
            if (l < KmStand)
            {
                return false;
            }
            else
            {
                KmStand = l;
                return true;
            }

        }
    }
}
