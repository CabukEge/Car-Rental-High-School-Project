using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Autovermietung
{
    class Menü //Allgemeine Klasse mit nur Formatierungsinhalten
    {
        int d;
        public Menü()
        {

        }
        public void Menüstart()
        {
           
            Menü_Hauptmenü();
        }

        public void Menü_Hauptmenü()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(2, 1);
            Console.Write("- Zur Dateneingabe ...");
                                                                         Console.SetCursorPosition(5, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                          Console.Write("<1>");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Privatkunde     oder     ");
            Console.ForegroundColor = ConsoleColor.Green;
                                                                             Console.Write("<2>");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Firmenkunde");
                                                                                  Console.SetCursorPosition(5, 6);
            Console.ForegroundColor = ConsoleColor.Green;
                                                                                  Console.Write("<3>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("PKW             oder     ");
            Console.ForegroundColor = ConsoleColor.Green;
                                                                                 Console.Write("<4>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("LKW");
                                                                                         Console.SetCursorPosition(5, 8);
            Console.ForegroundColor = ConsoleColor.Green;
                                                 Console.Write("<5>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Buchen          oder     ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<6>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Rückgabe");
            Console.SetCursorPosition(2, 11);
            Console.Write("- ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<F>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ahrzeugliste ausgeben");
            Console.SetCursorPosition(2, 13);
            Console.Write("- ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<K>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("undenliste ausgeben");
            Console.SetCursorPosition(2, 15);
            Console.Write("- ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<B>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("uchungsliste ausgeben");
            Console.SetCursorPosition(2, 18);
            Console.Write("- Dateien ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<S>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("peichern");
            Console.SetCursorPosition(2, 20);
            Console.Write("- Dateien ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<L>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("aden");
            Console.SetCursorPosition(2, 23);
            Console.Write("- Programm");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<E>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("nde");
            Console.SetCursorPosition(50, 1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(DateTime.Today.ToLongDateString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
        }
        public void Menü_Privatkunden()
        {
            Console.SetCursorPosition(2, 1); Console.Write("- Kunden hinzufügen");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(7, 5); Console.Write("<1>");
            Console.SetCursorPosition(7, 7); Console.Write("<2>");
            Console.SetCursorPosition(7, 10); Console.Write("<3>");
            Console.SetCursorPosition(7, 14); Console.Write("<4>");
            Console.SetCursorPosition(7, 16); Console.Write("<5>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(11, 5); Console.Write("     Vorname :");
            Console.SetCursorPosition(11, 7); Console.Write("      Zuname :");
            Console.SetCursorPosition(11, 10); Console.Write("Geburtsdatum :");
            Console.SetCursorPosition(11, 14); Console.Write("Führerschein :");
            Console.SetCursorPosition(11, 16); Console.Write("    Mitglied :");


        }
        public void Menü_Firmenkunde()
        {
            Console.SetCursorPosition(2, 1); Console.Write("- Kunden hinzufügen");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(7, 5); Console.Write("<1>");
            Console.SetCursorPosition(7, 7); Console.Write("<2>");
            Console.SetCursorPosition(7, 10); Console.Write("<3>");
            Console.SetCursorPosition(7, 14); Console.Write("<4>");
            Console.SetCursorPosition(7, 16); Console.Write("<5>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(11, 5); Console.Write("     Vorname :");
            Console.SetCursorPosition(11, 7); Console.Write("      Zuname :");
            Console.SetCursorPosition(11, 10); Console.Write("Geburtsdatum :");
            Console.SetCursorPosition(11, 14); Console.Write("Führerschein :");
            Console.SetCursorPosition(11, 16); Console.Write("Firmenname   :");
        }
        public void Menü_PKW_kaufen()
        {
            Console.SetCursorPosition(2, 1); Console.Write("- PKW hinzufügen");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i < 6; i++)
            {
                d = i * 3 + 4;
                Console.SetCursorPosition(5, d);
                Console.Write("<"+i+">");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(11, 4); Console.Write("Typ/Art    Km-Stand    Grundpreis   EUR/Km");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(11, 7); Console.Write("Combi          1000     999,99EUR       15");
            Console.SetCursorPosition(11, 10); Console.Write("Van            1000     999,99EUR       15");
            Console.SetCursorPosition(11, 13); Console.Write("Limousine      1000     999,99EUR       15");
            Console.SetCursorPosition(11, 16); Console.Write("Sport          1000     999,99EUR       15");
            Console.SetCursorPosition(11, 19); Console.Write("Panzer         1000     999,99EUR       15");
        }
        public void Menü_LKW_kaufen()
        {
            Console.SetCursorPosition(2, 1); Console.Write("- LKW hinzufügen");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i < 3; i++)
            {
                d = i * 3 + 4;
                Console.SetCursorPosition(5, d);
                Console.Write("<" + i + ">");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(11, 4); Console.Write("Typ/Art    Km-Stand    Grundpreis   EUR/Km");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(11, 7); Console.Write("Schlepper      1000        500EUR       15");
            Console.SetCursorPosition(11, 10); Console.Write("Tieflader      1000        500EUR       15");
        }
        public void Menü_LKW_Anzeigen()
        {
            Console.SetCursorPosition(1, 1); Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("PKW ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("|| ");
            Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("LKW ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("]");
            
            Console.SetCursorPosition(1, 21); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[←|→] PKW oder LKW  ||  [↓|↑] Seitenauswahl  ||  [E|Esc] Hauptmenü");
            Console.SetCursorPosition(1, 23); Console.Write("Mietpreis: EUR/KM  | Ladefläche: M^2  | Ladevolumen: M^3");
            Console.SetCursorPosition(1, 3); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer Fahrzeugtyp Kilometerstand Grundpreis Lad.Fläche Lad.Volumen Zul.Gewicht");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Menü_PKW_Anzeigen()
        {
            Console.SetCursorPosition(1, 1); Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("PKW ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("|| ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("LKW ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("]");

            Console.SetCursorPosition(1, 21); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[←|→] PKW oder LKW  ||  [↓|↑] Seitenauswahl  ||  [E|Esc] Hauptmenü");
            Console.SetCursorPosition(1, 23); Console.Write("Mietpreis: EUR/KM  | Auto: Automatik  | Klima: Klimaanlage  | Sitz: Sitzplätze");
            Console.SetCursorPosition(1, 3); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer Fahrzeugtyp Kilometerstand Grundpreis Mietpreis Auto Klima Sitz");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Menü_Privat_Anzeigen()
        {
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White; Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("Privatkunden ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("|| Firmenkunden ]");
            Console.SetCursorPosition(1, 21); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[←|→] Privat- oder Firmenkunde  ||  [↓|↑] Seitenauswahl  ||  [E|Esc] Hauptmenü");
            Console.SetCursorPosition(1, 3); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer  Vorname  Nachname    Geburtstag  Führerschein  Mitglied");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Menü_Firmen_Anzeigen()
        {
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White; Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("Privatkunden || ");
            Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("Firmenkunden");
            Console.ForegroundColor = ConsoleColor.White; Console.Write(" ]");
            Console.SetCursorPosition(1, 21); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[←|→] Privat- oder Firmenkunde  ||  [↓|↑] Seitenauswahl  ||  [E|Esc] Hauptmenü");
            Console.SetCursorPosition(1, 3); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer  Vorname  Nachname    Geburtstag  Führerschein  Firmenname");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Menü_Buchung_Anzeigen()
        {
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White; Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("Buchungen");
            Console.ForegroundColor = ConsoleColor.White; Console.Write(" ]");
            Console.SetCursorPosition(1, 21); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[↓|↑] Seitenauswahl  ||  [E|Esc] Hauptmenü");
            Console.SetCursorPosition(1, 3); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nr Status     F  Typ  Fahrzeugtyp    K  Kundenart    Nachname    Vorname");
        }
        public void Menü_Buchung_Aufnehmen()
        {
            Console.Clear();
            Console.SetCursorPosition(2, 1); Console.Write("- Buchung aufnehmen");
        }
        public void Menü_Buchung_Kundenauswahl()
        {
            Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ Privat | Firmen ]");
            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(27, 1); Console.Write("Privat");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(50, 1); Console.Write("Wähle Sie einen Kunden aus!");
            
            Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(1, 23); Console.Write("[←|→] Privat oder Firmenkunde  ||  [↓|↑] Seitenauswahl  ||  [E|Esc] Hauptmenü");
        }
        public void Menü_Buchung_Fahrzeugauswahl()
        {
            Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ PKW | LKW ]");
            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(27, 1); Console.Write("PKW");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(50, 1); Console.Write("Wähle Sie ein Fahrzeug aus!");

            Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(1, 23); Console.Write("[←|→] PKW oder LKW  ||  [↓|↑] Seitenauswahl");
        }
        public void Menü_Buchung_Beenden()
        {
            Console.Clear();
            Console.SetCursorPosition(2, 1); Console.Write("- Buchung beenden");
            Console.SetCursorPosition(1, 4); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nr Status     F  Typ  Fahrzeugtyp    K  Kundenart    Nachname    Vorname");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(1, 23); Console.Write("[↓|↑] Seitenauswahl                   ");
        }
    }
}
