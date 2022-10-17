using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Autovermietung
{
    class Verwaltung
    {
        ConsoleKeyInfo Taste;
        Menü m = new Menü();
        int Zeiger, Seite, SeiteAnzahl, Auswahl, Auswahl2, Auswahl3, Auswahl4, Kilometer;
        bool s, d, f, k, Fehler, Fuhrerschein, Mitglied;
        string Vorname, Zuname, Firmenname;
        string Privatkundenpfad, Firmenkundenpfad, PKWpfad, LKWpfad, Buchungspfad;
        char cFahrzeug, cKunde;
        DateTime Date, Min;
        Kunden[] PrivatKunden; int Kundenzaehler;
        Kunden[] FirmenKunden; int Kundenzaehler2;
        Fahrzeug[] PKWListe; int Fahrzeugzahler;
        Fahrzeug[] LKWListe; int Fahrzeugzahler2;
        Buchung[] Buchungsliste; int Buchungszähler;


        StreamWriter file;

        public void Hauptmenü()//Wird beim Start ausgeführt
        {
            // Pfad einsetzen 
            Privatkundenpfad = @"*";
            Firmenkundenpfad = @"*";
            PKWpfad = @"*";
            LKWpfad = @"*";
            Buchungspfad = @"*";
            //Test_Daten();
            m.Menüstart();
            Hauptmenü_Steuerung();
        }
        public void Hauptmenü_Steuerung()//Steuerung im Hauptmenü
        {
            Taste = Console.ReadKey(true);
            do
            {
                switch (Taste.KeyChar)
                {
                    case '1': Privatkunden_hinzufugen(); break;
                    case '2': Firmenkunden_hinzufügen(); break;
                    case '3': PKW_kaufen(); break;
                    case '4': LKW_kaufen(); break;
                    case '5': Buchung_aufnehmen(); break;
                    case '6': Buchung_beenden(); break;
                    case 'f': Fahrzeug_Anzeige(); break;
                    case 'k': Kunden_Anzeige(); break;
                    case 'b': Buchung_Anzeige(); break;
                    case 's': Dateien_speichern(); break;
                    case 'l': Dateien_laden(); break;
                }
                m.Menü_Hauptmenü();
                Taste = Console.ReadKey(true);
            } while (Taste.Key != ConsoleKey.E);
        }
        public void Privatkunden_hinzufugen()//Privatkunden Ablauf
        {
            Console.Clear();
            m.Menü_Privatkunden();
            Vorname_Eingabe();
            Zuname_Eingabe();
            Geburtstag_Eingabe();
            Fuhrerschein_Eingabe();
            Mitglied_Eingabe();
            Bestätigung_PrivatKunden_Eingabe();
        }
        public void Firmenkunden_hinzufügen()//Firmenkunden Ablauf
        {
            Console.Clear();
            m.Menü_Firmenkunde();
            Vorname_Eingabe();
            Zuname_Eingabe();
            Geburtstag_Eingabe();
            Fuhrerschein_Eingabe();
            Action_Zeile_Clear();
            Firmenname_Eingabe();
            Console.CursorVisible = false;
            Bestätigung_FirmenKunden_Eingabe();
        }
        public void PKW_kaufen()//PKW Ablauf
        {
            Console.Clear();
            m.Menü_PKW_kaufen();
            s = false;
            while (!s)
            {
                Taste = Console.ReadKey(true);
                switch (Taste.KeyChar)
                {
                    case '1':
                        Array.Resize(ref PKWListe, Fahrzeugzahler + 1);
                        PKWListe[Fahrzeugzahler] = new PKW(1000, 15.0, 1000, "Combi", true, false, 9, false);
                        s = true;
                        Fahrzeugzahler++;
                        break;
                    case '2':
                        Array.Resize(ref PKWListe, Fahrzeugzahler + 1);
                        PKWListe[Fahrzeugzahler] = new PKW(1000, 15.0, 1000, "Van", true, true, 9, false);
                        s = true;
                        Fahrzeugzahler++;
                        break;
                    case '3':
                        Array.Resize(ref PKWListe, Fahrzeugzahler + 1);
                        PKWListe[Fahrzeugzahler] = new PKW(1000, 15.0, 1000, "Limousine", false, true, 9, false);
                        s = true;
                        Fahrzeugzahler++;
                        break;
                    case '4':
                        Array.Resize(ref PKWListe, Fahrzeugzahler + 1);
                        PKWListe[Fahrzeugzahler] = new PKW(1000, 15.0, 1000, "Sport", false, false, 9, false);
                        s = true;
                        Fahrzeugzahler++;
                        break;
                    case '5':
                        Array.Resize(ref PKWListe, Fahrzeugzahler + 1);
                        PKWListe[Fahrzeugzahler] = new PKW(1000, 15.0, 1000, "Panzer", false, false, 9, false);
                        s = true;
                        Fahrzeugzahler++;
                        break;
                }
            }
        }
        public void LKW_kaufen()//LKW Ablauf
        {
            Console.Clear();
            m.Menü_LKW_kaufen();

            s = false;
            while (!s)
            {
                Taste = Console.ReadKey(true);
                switch (Taste.KeyChar)
                {
                    case '1':
                        Array.Resize(ref LKWListe, Fahrzeugzahler2 + 1);
                        LKWListe[Fahrzeugzahler2] = new LKW(500, 100, 1000, "Schlepper", 100, 100, 1000, false);
                        s = true;
                        Fahrzeugzahler2++;
                        break;
                    case '2':
                        Array.Resize(ref LKWListe, Fahrzeugzahler2 + 1);
                        LKWListe[Fahrzeugzahler2] = new LKW(500, 100, 1000, "Tieflader", 100, 100, 1000, false);
                        s = true;
                        Fahrzeugzahler2++;
                        break;

                }
            }

        }
        public void Buchung_aufnehmen()//Buchung Aufnehmen Ablauf
        {
            f = false; k = false; Seite = 0; Auswahl = 0;
            Buchung_Kunden_Auswahl();
        }
        public void Buchung_beenden()//Buchung Beenden Ablauf
        {
            f = false; k = false; Seite = 0; Auswahl = 0;
            m.Menü_Buchung_Beenden();
            Buchung_Buchung_Auswahl();
        }
        public void Fahrzeug_Anzeige()//Fahrzeuge anzeigen
        {
            if (d == false)
            {
                if (PKWListe == null)
                {
                    Console.Clear();
                    m.Menü_PKW_Anzeigen();
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein PKW eingetragen sein!");
                }
                else
                {
                    Seitenanzahl(PKWListe);
                    Console.Clear();
                    m.Menü_PKW_Anzeigen();
                    for (int i = 0; i < 5 && i < PKWListe.Length; i++)
                    {
                        if (i + Seite * 5 < PKWListe.Length)
                        {
                            Tabelle_PKW(i + Seite * 5, i, 3, 5);
                        }
                    }
                }
            }
            else
            {
                if (LKWListe == null)
                {
                    Console.Clear();
                    m.Menü_LKW_Anzeigen();
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein LKW eingetragen sein!");
                }
                else
                {
                    Seitenanzahl(LKWListe);
                    Console.Clear();
                    m.Menü_LKW_Anzeigen();
                    for (int i = 0; i < 5 && i < LKWListe.Length; i++)
                    {
                        if (i + Seite * 5 < LKWListe.Length)
                        {
                            Tabelle_LKW(i + Seite * 5, i, 3, 5);
                        }
                    }
                }

            }
            Seite++; SeiteAnzahl++;
            Console.SetCursorPosition(60, 1); Console.Write("Seite[" + Seite + "/" + SeiteAnzahl + "]");
            Seite--; SeiteAnzahl--;
            Taste = Console.ReadKey(true);
            if (Taste.Key == ConsoleKey.Escape || Taste.Key == ConsoleKey.E) { d = false; Seite = 0; }
            else
            {
                if (Taste.Key == ConsoleKey.LeftArrow)
                {
                    d = false;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.RightArrow)
                {
                    d = true;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.DownArrow && Seite < SeiteAnzahl)
                {
                    Seite++;
                }
                else if (Taste.Key == ConsoleKey.UpArrow && Seite >= 1)
                {
                    Seite--;
                }
                Fahrzeug_Anzeige();
            }
        }
        public void Kunden_Anzeige()//Kunden anzeigen
        {
            Console.Clear();

            if (d == false)
            {
                if (PrivatKunden == null)
                {
                    Console.Clear();
                    m.Menü_Privat_Anzeigen();
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein Privatkunde eingetragen sein!");
                }
                else
                {
                    Seitenanzahl(PrivatKunden);
                    Console.Clear();
                    m.Menü_Privat_Anzeigen();
                    for (int i = 0; i < 5 && i < PrivatKunden.Length; i++)
                    {
                        if (i + Seite * 5 < PrivatKunden.Length)
                        {
                            Tabelle_Privatkunde(i + Seite * 5, i, 3, 5);
                        }
                    }
                }
            }
            else
            {
                if (FirmenKunden == null)
                {
                    Console.Clear();
                    m.Menü_Firmen_Anzeigen();
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein Firmenkunde eingetragen sein!");
                }
                else
                {
                    Seitenanzahl(FirmenKunden);
                    Console.Clear();
                    m.Menü_Firmen_Anzeigen();
                    for (int i = 0; i < 5 && i < FirmenKunden.Length; i++)
                    {
                        if (i + Seite * 5 < FirmenKunden.Length)
                        {
                            Tabelle_Firmenkunde(i + Seite * 5, i, 3, 5);
                        }
                    }
                }

            }
            Seite++; SeiteAnzahl++;
            Console.SetCursorPosition(60, 1); Console.Write("Seite[" + Seite + "/" + SeiteAnzahl + "]");
            Seite--; SeiteAnzahl--;
            Taste = Console.ReadKey(true);
            if (Taste.Key == ConsoleKey.Escape || Taste.Key == ConsoleKey.E) { d = false; Seite = 0; }
            else
            {
                if (Taste.Key == ConsoleKey.LeftArrow)
                {
                    d = false;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.RightArrow)
                {
                    d = true;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.DownArrow && Seite < SeiteAnzahl)
                {
                    Seite++;
                }
                else if (Taste.Key == ConsoleKey.UpArrow && Seite >= 1)
                {
                    Seite--;
                }
                Kunden_Anzeige();
            }
        }
        public void Buchung_Anzeige()//Buchung Anzeige
        {
            if (Buchungsliste == null)
            {
                Console.Clear();
                m.Menü_Buchung_Anzeigen();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens eine Buchung eingetragen sein!");
            }
            else
            {
                Seitenanzahl(Buchungsliste);
                Console.Clear();
                m.Menü_Buchung_Anzeigen();
                for (int i = 0; i < 5 && i < Buchungsliste.Length; i++)
                {
                    if (i + Seite * 5 < Buchungsliste.Length)
                    {
                        Tabelle_Buchungen(i + Seite * 5, i, 3, 5);
                    }
                }
            }
            Seite++; SeiteAnzahl++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(60, 1); Console.Write("Seite[" + Seite + "/" + SeiteAnzahl + "]");
            Seite--; SeiteAnzahl--;
            Taste = Console.ReadKey(true);
            if (Taste.Key == ConsoleKey.Escape || Taste.Key == ConsoleKey.E) { d = false; Seite = 0; }
            else
            {
                if (Taste.Key == ConsoleKey.DownArrow && Seite < SeiteAnzahl)
                {
                    Seite++;
                }
                else if (Taste.Key == ConsoleKey.UpArrow && Seite >= 1)
                {
                    Seite--;
                }
                Buchung_Anzeige();
            }
        }
        public void Dateien_speichern()//Datein Speichern Ablauf (5 txt Dateien)
        {
            Speichern_Privatkunden();
            Speichern_Firmenkunden();
            Speichern_PKW();
            Speichern_LKW();
            Speichern_Buchungen();
        }
        public void Dateien_laden()//LEER LEER LEER
        {

        }
        public void Vorname_Eingabe()//Privatkunde / Firmenkunde abfrage des Vornames
        {

            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(26, 5);
            Vorname = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(26, 5);
            Console.Write(Vorname);
            Console.ForegroundColor = ConsoleColor.White;
            if (Vorname.Length > 2)
            {
                for (int i = 25; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 7);
                    Console.Write(" ");
                }
                for (int i = 25; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 1);
                    Console.Write(" ");
                }
            }
            else
            {
                for (int i = 26; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 5);
                    Console.Write("  ");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(26, 1); Console.Write("Vorname zu kurz!");
                Vorname_Eingabe();
            }
        }
        public void Zuname_Eingabe()//Privatkunde / Firmenkunde Abfrage des Nachnamens
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(26, 7);
            Zuname = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(26, 7);
            Console.Write(Zuname);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            if (Zuname.Length > 2)
            {
                for (int i = 26; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 1);
                    Console.Write("  ");
                }

            }
            else
            {
                for (int i = 26; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 7);
                    Console.Write("  ");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(26, 1); Console.Write("Zuname zu kurz!");

                Zuname_Eingabe();
            }
        }
        public void Geburtstag_Eingabe()//Privatkunde / Firmenkunde Abfrage des Geburtsdatums
        {
            Date = new DateTime(2000, 1, 1); //Gebi
            while (Taste.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(26, 1); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("Kleine Info: Ab hier steuert man mit den Pfeiltasten!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (Zeiger == 0)
                {
                    Console.SetCursorPosition(26, 11); Console.Write("↑↑");
                    Console.SetCursorPosition(29, 11); Console.Write("  ");
                    Console.SetCursorPosition(26, 9); Console.Write("↓↓");
                    Console.SetCursorPosition(29, 9); Console.Write("  ");
                }
                else if (Zeiger == 1)
                {
                    Console.SetCursorPosition(26, 11); Console.Write("  ");
                    Console.SetCursorPosition(29, 11); Console.Write("↑↑");
                    Console.SetCursorPosition(32, 11); Console.Write("    ");
                    Console.SetCursorPosition(26, 9); Console.Write("  ");
                    Console.SetCursorPosition(29, 9); Console.Write("↓↓");
                    Console.SetCursorPosition(32, 9); Console.Write("    ");
                }
                else if (Zeiger == 2)
                {
                    Console.SetCursorPosition(29, 11); Console.Write("  ");
                    Console.SetCursorPosition(32, 11); Console.Write("↑↑↑↑");
                    Console.SetCursorPosition(29, 9); Console.Write("  ");
                    Console.SetCursorPosition(32, 9); Console.Write("↓↓↓↓");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(26, 10);
                Console.Write(Date.ToShortDateString());
                Taste = Console.ReadKey(true);
                switch (Taste.Key)
                {
                    case ConsoleKey.DownArrow:
                        Min = new DateTime(1900, 1, 1);
                        if (Zeiger == 0 && Date > Min) { Date = Date.AddDays(-1.0); }
                        if (Zeiger == 1 && Date > Min) { Date = Date.AddMonths(-1); }
                        if (Zeiger == 2 && Date > Min) { Date = Date.AddYears(-1); }
                        if (Date < Min) { Date = Min; }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Zeiger == 0 && Date < DateTime.Today) { Date = Date.AddDays(1.0); }
                        if (Zeiger == 1 && Date < DateTime.Today) { Date = Date.AddMonths(1); }
                        if (Zeiger == 2 && Date < DateTime.Today) { Date = Date.AddYears(1); }
                        if (Date > DateTime.Today) { Date = DateTime.Today; }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Zeiger < 2)
                        {
                            Zeiger++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Zeiger > 0)
                        {
                            Zeiger--;
                        }
                        break;
                }
            }
            Console.SetCursorPosition(26, 11); Console.Write("          ");
            Console.SetCursorPosition(26, 9); Console.Write("          ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(26, 10); Console.Write(Date.ToShortDateString());
        }
        public void Fuhrerschein_Eingabe()//Privatkunde / Firmenkunden Abfrage des Führerscheins
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(26, 14); Console.Write("Vorhanden"); // Führerschein
            Fuhrerschein = true;
            Taste = Console.ReadKey();
            while (Taste.Key != ConsoleKey.Enter)
            {
                switch (Taste.Key)
                {
                    case ConsoleKey.UpArrow:
                        Fuhrerschein = true;
                        break;
                    case ConsoleKey.DownArrow:
                        Fuhrerschein = false;
                        break;
                }
                if (Fuhrerschein == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(26, 14); Console.Write("Vorhanden");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(26, 14); Console.Write("fehlend  ");
                }
                Taste = Console.ReadKey();

            }
        }
        public void Mitglied_Eingabe()//Privatkunde Abfrage der Mitgliedschaft
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(26, 16); Console.Write("Ja"); // Mitglied
            Mitglied = true;
            Taste = Console.ReadKey();
            while (Taste.Key != ConsoleKey.Enter)
            {
                switch (Taste.Key)
                {
                    case ConsoleKey.UpArrow:
                        Mitglied = true;
                        break;
                    case ConsoleKey.DownArrow:
                        Mitglied = false;
                        break;
                }
                if (Mitglied == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(26, 16); Console.Write("Ja  ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(26, 16); Console.Write("Nein");
                }
                Taste = Console.ReadKey();
            }
        }
        public void Bestätigung_PrivatKunden_Eingabe() // Privatkunde Bestätigung der Eingaben
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(26, 1); Console.Write("Enter zum Bestätigen!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("     Escape zum Abbrechen!                  ");
            do
            {
                Taste = Console.ReadKey(true);
                if (Taste.Key == ConsoleKey.Enter)
                {
                    Array.Resize(ref PrivatKunden, Kundenzaehler + 1);
                    PrivatKunden[Kundenzaehler] = new Privatkunden(Vorname, Zuname, Date, Fuhrerschein, Mitglied, false);
                    Kundenzaehler++;
                }
            }
            while (Taste.Key != ConsoleKey.Enter && Taste.Key != ConsoleKey.Escape);
        }
        public void Firmenname_Eingabe()// Firmenkunden Abfrage des Firmensnamen
        {
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(26, 16);
            Firmenname = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(26, 16);
            Console.Write(Firmenname);
            if (Firmenname.Length >= 2)
            {
                for (int i = 25; i < Console.WindowWidth; i++)
                {
                    //Console.SetCursorPosition(i, 16);
                    //Console.Write(" ");
                }
            }
            else
            {
                for (int i = 26; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 16);
                    Console.Write("  ");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(26, 1); Console.Write("Firmenname muss mindestens 2 Zeichen enthalten!");
                Firmenname_Eingabe();
            }
        }
        public void Bestätigung_FirmenKunden_Eingabe()// Firmenkunden Bestätigung der Eingaben
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(26, 1); Console.Write("Enter zum Bestätigen!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("     Escape zum Abbrechen!                  ");
            do
            {
                Taste = Console.ReadKey(true);
                if (Taste.Key == ConsoleKey.Enter)
                {
                    Array.Resize(ref FirmenKunden, Kundenzaehler2 + 1);
                    FirmenKunden[Kundenzaehler2] = new Firmenkunde(Vorname, Zuname, Date, Fuhrerschein, Firmenname, false);
                    Kundenzaehler2++;
                }
            }
            while (Taste.Key != ConsoleKey.Enter && Taste.Key != ConsoleKey.Escape);
        }
        public void Action_Zeile_Clear()// y = 1 Zeile löschen
        {
            for (int i = 25; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write(" ");
            }
        }
        public void Seitenanzahl(Array a)// Pro 5 Array.Lenght -> Seite++
        {
            SeiteAnzahl = 0;
            for (int Zahler = a.Length - 5; Zahler > 0; Zahler = Zahler - 5)
            {
                SeiteAnzahl++;
            }
        }
        public void Seitenanzahl2(Array a)// Pro 15 Array.Lengt -> Seite++
        {
            SeiteAnzahl = 0;
            for (int Zahler = a.Length - 15; Zahler > 0; Zahler = Zahler - 15)
            {
                SeiteAnzahl++;
            }
        }
        public void Tabelle_PKW(int i, int o, int a, int s)// Tabelle der PKW Anzeige
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, o * a + s); Console.WriteLine(i);
            Console.SetCursorPosition(8, o * a + s); Console.WriteLine(PKWListe[i].get_Fahrzeugtyp());
            Console.SetCursorPosition(20, o * a + s); Console.WriteLine(PKWListe[i].get_KmStand());
            Console.SetCursorPosition(35, o * a + s); Console.WriteLine(PKWListe[i].get_Grundpreis() + "EUR");
            Console.SetCursorPosition(46, o * a + s); Console.WriteLine(PKWListe[i].get_Mietpreis() + "EUR/Km");
            if (PKWListe[i].get_Klimaanlage() == true)
            {
                Console.SetCursorPosition(56, o * a + s); Console.Write("Ja");
            }
            else
            {
                Console.SetCursorPosition(56, o * a + s); Console.Write("Nein");
            }
            if (PKWListe[i].get_Automatik() == true)
            {
                Console.SetCursorPosition(61, o * a + s); Console.Write("Ja");
            }
            else
            {
                Console.SetCursorPosition(61, o * a + s); Console.Write("Nein");
            }
            Console.SetCursorPosition(67, o * a + s); Console.WriteLine(PKWListe[i].get_Sitzplatze());
        }
        public void Tabelle_LKW(int i, int o, int a, int s)// Tabelle der LKW Anzeige
        {
            Console.SetCursorPosition(1, o * a + s); Console.WriteLine(i);
            Console.SetCursorPosition(8, o * a + s); Console.WriteLine(LKWListe[i].get_Fahrzeugtyp());
            Console.SetCursorPosition(20, o * a + s); Console.WriteLine(LKWListe[i].get_KmStand());
            Console.SetCursorPosition(35, o * a + s); Console.WriteLine(LKWListe[i].get_Grundpreis() + "EUR");
            Console.SetCursorPosition(46, o * a + s); Console.WriteLine(LKWListe[i].get_Ladefläche() + "m^2");
            Console.SetCursorPosition(57, o * a + s); Console.WriteLine(LKWListe[i].get_Ladevolumen() + "m^3");
            Console.SetCursorPosition(69, o * a + s); Console.WriteLine(LKWListe[i].get_Zugewicht() + "kg");
        }
        public void Tabelle_Privatkunde(int i, int o, int a, int s)// Tabelle der Privatkunden Anzeige
        {
            Console.SetCursorPosition(1, o * a + s); Console.WriteLine(i);
            Console.SetCursorPosition(9, o * a + s); Console.WriteLine(PrivatKunden[i].get_Vorname());
            Console.SetCursorPosition(18, o * a + s); Console.WriteLine(PrivatKunden[i].get_Zuname());
            Console.SetCursorPosition(30, o * a + s); Console.WriteLine(PrivatKunden[i].get_Gebi().ToShortDateString());
            if (PrivatKunden[i].get_Fuhrerschein() == true)
            {
                Console.SetCursorPosition(42, o * a + s); Console.Write("Ja");
            }
            else
            {
                Console.SetCursorPosition(42, o * a + s); Console.Write("Nein");
            }
            if (PrivatKunden[i].get_Mitglied() == true)
            {
                Console.SetCursorPosition(56, o * a + s); Console.Write("Ja");
            }
            else
            {
                Console.SetCursorPosition(56, o * a + s); Console.Write("Nein");
            }

        }
        public void Tabelle_Firmenkunde(int i, int o, int a, int s)// Tabelle der Firmenkunden Anzeige
        {
            Console.SetCursorPosition(1, o * a + s); Console.WriteLine(i);
            Console.SetCursorPosition(9, o * a + s); Console.WriteLine(FirmenKunden[i].get_Vorname());
            Console.SetCursorPosition(18, o * a + s); Console.WriteLine(FirmenKunden[i].get_Zuname());
            Console.SetCursorPosition(30, o * a + s); Console.WriteLine(FirmenKunden[i].get_Gebi().ToShortDateString());
            if (FirmenKunden[i].get_Fuhrerschein() == true)
            {
                Console.SetCursorPosition(42, o * a + s); Console.Write("Ja");
            }
            else
            {
                Console.SetCursorPosition(42, o * a + s); Console.Write("Nein");
            }
            Console.SetCursorPosition(56, o * a + s); Console.WriteLine(FirmenKunden[i].get_Firmenname());
        }
        public void Tabelle_Buchungen(int i, int o, int a, int s)// Tabelle der Buchungs Anzeige
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, o * a + s); Console.WriteLine(i);
            if (Buchungsliste[i].get_Status() == 'a')
            {
                Console.SetCursorPosition(4, o * a + s); Console.Write("Aktiv");
            }
            else
            {
                Console.SetCursorPosition(4, o * a + s); Console.Write("Beendet");
            }
            Console.SetCursorPosition(15, o * a + s); Console.WriteLine(Buchungsliste[i].get_Fahrzeugnummer());
            if (Buchungsliste[i].get_Fahrzeugtyp() == 'p')
            {
                Console.SetCursorPosition(18, o * a + s); Console.Write("PKW  " + PKWListe[i].get_Fahrzeugtyp());

            }
            else
            {
                Console.SetCursorPosition(18, o * a + s); Console.Write("LKW  " + LKWListe[i].get_Fahrzeugtyp());
            }
            Console.SetCursorPosition(38, o * a + s); Console.WriteLine(Buchungsliste[i].get_Kundennummer());
            if (Buchungsliste[i].get_Kundenart() == 'p')
            {
                Console.SetCursorPosition(41, o * a + s); Console.Write("Privatkunde");
                Console.SetCursorPosition(54, o * a + s); Console.Write(PrivatKunden[i].get_Zuname());
                Console.SetCursorPosition(66, o * a + s); Console.Write(PrivatKunden[i].get_Vorname());
            }
            else
            {
                Console.SetCursorPosition(41, o * a + s); Console.Write("Firmakunde");
                Console.SetCursorPosition(54, o * a + s); Console.Write(FirmenKunden[i].get_Zuname());
                Console.SetCursorPosition(66, o * a + s); Console.Write(FirmenKunden[i].get_Vorname());
            }
        }
        public void Buchung_Kunden_Auswahl()// Buchung Auswahl der Kunden
        {
            Console.Clear();
            m.Menü_Buchung_Aufnehmen();
            m.Menü_Buchung_Kundenauswahl();

            if (k == false)
            {
                if (PrivatKunden == null)
                {
                    Console.Clear();
                    m.Menü_Buchung_Kundenauswahl();
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ Privat | Firmen ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(27, 1); Console.Write("Privat");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein Privatkunden eingetragen sein!");
                }
                else
                {
                    Seitenanzahl2(PrivatKunden);
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ Privat | Firmen ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(27, 1); Console.Write("Privat");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(1, 4); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer  Vorname  Nachname    Geburtstag  Führerschein  Mitglied");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < 15 && i < PrivatKunden.Length; i++)
                    {
                        if (i + Seite * 15 < PrivatKunden.Length)
                        {
                            Tabelle_Privatkunde(i + Seite * 15, i, 1, 6);
                        }
                    }
                }
            }
            else
            {
                if (FirmenKunden == null)
                {
                    Console.Clear();
                    m.Menü_Buchung_Kundenauswahl();
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ Privat | Firmen ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(36, 1); Console.Write("Firmen");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein Firmenkunden eingetragen sein!");
                }
                else
                {
                    Seitenanzahl2(FirmenKunden);
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ Privat | Firmen ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(36, 1); Console.Write("Firmen");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(1, 4); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer  Vorname  Nachname    Geburtstag  Führerschein  Firmenname");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < 15 && i < FirmenKunden.Length; i++)
                    {
                        if (i + Seite * 15 < FirmenKunden.Length)
                        {
                            Tabelle_Firmenkunde(i + Seite * 15, i, 1, 6);
                        }
                    }
                }
            }
            Taste = Console.ReadKey();
            if (Taste.Key == ConsoleKey.Escape || Taste.Key == ConsoleKey.E) { k = false; Seite = 0; }
            else
            if (Taste.Key == ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, Auswahl + 6); Console.Write("→");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(1, 23); Console.Write("[↓|↑] Kundenauswahl                                                                     ");
                Console.ForegroundColor = ConsoleColor.White;
                Auswahl = 0;
                do
                {
                    switch (Taste.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (Auswahl < 14 && k == false && PrivatKunden.Length - 1 > Auswahl + 15 * Seite || Auswahl < 14 && k == true && FirmenKunden.Length - 1 > Auswahl + 15 * Seite) { Auswahl++; }
                            break;
                        case ConsoleKey.UpArrow:
                            if (Auswahl > 0) { Auswahl--; }
                            break;
                    }
                    Console.SetCursorPosition(0, Auswahl + 5); Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, Auswahl + 6); Console.Write("→");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, Auswahl + 7); Console.Write(" ");
                    Taste = Console.ReadKey(true);
                } while (Taste.Key != ConsoleKey.Enter && Taste.Key != ConsoleKey.Escape);
                if (Taste.Key == ConsoleKey.Enter)
                {
                    Auswahl2 = Auswahl + 15 * Seite;
                    Auswahl = 0; Seite = 0;
                    Buchung_Fahrzeug_Auswahl();
                }
                if (Taste.Key == ConsoleKey.Escape)
                {
                    Auswahl = 0;
                    Buchung_Kunden_Auswahl();
                }
            }
            else
            {
                if (Taste.Key == ConsoleKey.LeftArrow)
                {
                    k = false;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.RightArrow)
                {
                    k = true;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.DownArrow && Seite < SeiteAnzahl)
                {
                    Seite++;
                }
                else if (Taste.Key == ConsoleKey.UpArrow && Seite >= 1)
                {
                    Seite--;
                }
                Buchung_Kunden_Auswahl();
            }
        }
        public void Buchung_Fahrzeug_Auswahl()// Buchung Auswahl des Fahrzeuges
        {
            Console.Clear();
            m.Menü_Buchung_Aufnehmen();
            m.Menü_Buchung_Fahrzeugauswahl();
            if (Fehler == true)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.SetCursorPosition(15, 3);
                Console.Write("Fahrzeug Nummer " + Auswahl3 + " ist bereits vermietet!"); Console.ForegroundColor = ConsoleColor.Red;
                Fehler = false;
            }
            if (f == false)
            {
                if (PKWListe == null)
                {
                    Console.Clear();
                    m.Menü_Buchung_Kundenauswahl();
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ PKW | LKW ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(27, 1); Console.Write("PKW");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein Fahrzeug eingetragen sein!");
                }
                else
                {
                    Seitenanzahl2(PKWListe);
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ PKW | LKW ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(27, 1); Console.Write("PKW");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(1, 4); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer Fahrzeugtyp Kilometerstand Grundpreis Mietpreis Auto Klima Sitz");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < 15 && i < PKWListe.Length; i++)
                    {
                        if (i + Seite * 15 < PKWListe.Length)
                        {
                            Tabelle_PKW(i + Seite * 15, i, 1, 6);
                        }
                    }
                }
            }
            else
            {
                if (LKWListe == null)
                {
                    Console.Clear();
                    m.Menü_Buchung_Fahrzeugauswahl();
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ PKW | LKW ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(33, 1); Console.Write("LKW");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens ein Fahrzeug eingetragen sein!");
                }
                else
                {

                    Seitenanzahl2(LKWListe);
                    Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(25, 1); Console.Write("[ PKW | LKW ]");
                    Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(33, 1); Console.Write("LKW");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(1, 4); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Nummer Fahrzeugtyp Kilometerstand Grundpreis Lad.Fläche Lad.Volumen Zul.Gewicht");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < 15 && i < LKWListe.Length; i++)
                    {
                        if (i + Seite * 15 < LKWListe.Length)
                        {
                            Tabelle_LKW(i + Seite * 15, i, 1, 6);
                        }
                    }
                }
            }
            Taste = Console.ReadKey();
            if (Taste.Key == ConsoleKey.Escape || Taste.Key == ConsoleKey.E) { f = false; Seite = 0; Buchung_Kunden_Auswahl(); }
            else
            if (Taste.Key == ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(1, 23); Console.Write("[↓|↑] Fahrzeugauswahl                                                               ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, Auswahl + 6); Console.Write("→");
                Console.ForegroundColor = ConsoleColor.White;
                Auswahl = 0;
                do
                {
                    switch (Taste.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (Auswahl < 14 && f == false && PKWListe.Length - 1 > Auswahl + 15 * Seite || Auswahl < 14 && f == true && LKWListe.Length - 1 > Auswahl + 15 * Seite) { Auswahl++; }
                            break;
                        case ConsoleKey.UpArrow:
                            if (Auswahl > 0) { Auswahl--; }
                            break;
                    }
                    Console.SetCursorPosition(0, Auswahl + 5); Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, Auswahl + 6); Console.Write("→");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, Auswahl + 7); Console.Write(" ");
                    Taste = Console.ReadKey(true);
                } while (Taste.Key != ConsoleKey.Enter && Taste.Key != ConsoleKey.Escape);
                if (Taste.Key == ConsoleKey.Enter)
                {
                    Auswahl3 = Auswahl + 15 * Seite;
                    if (f == false)
                    {
                        if (PKWListe[Auswahl3].get_Vermietet() == true)
                        {
                            Fehler = true;
                            Auswahl = 0;
                            Buchung_Fahrzeug_Auswahl();
                        }
                        else
                        {
                            Buchung_Abschluss();
                        }
                    }
                    else
                    {
                        if (LKWListe[Auswahl3].get_Vermietet() == true)
                        {
                            Auswahl = 0;
                            Fehler = true;
                            Buchung_Fahrzeug_Auswahl();
                        }
                        else
                        {
                            Buchung_Abschluss();
                        }
                    }

                }
                else if (Taste.Key == ConsoleKey.Escape)
                {
                    Auswahl = 0;
                    Buchung_Fahrzeug_Auswahl();
                }
            }
            else
            {
                if (Taste.Key == ConsoleKey.LeftArrow)
                {
                    f = false;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.RightArrow)
                {
                    f = true;
                    Seite = 0;
                }
                else if (Taste.Key == ConsoleKey.DownArrow && Seite < SeiteAnzahl)
                {
                    Seite++;
                }
                else if (Taste.Key == ConsoleKey.UpArrow && Seite >= 1)
                {
                    Seite--;
                }
                Buchung_Fahrzeug_Auswahl();
            }
        }
        public void Buchung_Buchung_Auswahl()// Buchung Beendigung der Buchung
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            m.Menü_Buchung_Beenden();
            if (Fehler == true)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.SetCursorPosition(15, 3);
                Console.Write("Buchungs Nummer " + Auswahl4 + " ist bereits fertig!"); Console.ForegroundColor = ConsoleColor.Red;
                Fehler = false;
            }
            if (Buchungsliste == null)
            {
                Console.Clear();
                m.Menü_Buchung_Kundenauswahl();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, 10); Console.Write("Es muss mindestens eine Buchung eingetragen sein!");
            }
            else
            {
                Seitenanzahl2(Buchungsliste);
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < 15 && i < Buchungsliste.Length; i++)
                {
                    if (i + Seite * 15 < Buchungsliste.Length)
                    {
                        Tabelle_Buchungen(i + Seite * 15, i, 1, 6);
                    }
                }
            }

            Taste = Console.ReadKey();
            if (Taste.Key == ConsoleKey.Escape || Taste.Key == ConsoleKey.E) { Seite = 0; }
            else
            if (Taste.Key == ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(1, 23); Console.Write("[↓|↑] Buchungsauswahl                                                               ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, Auswahl + 6); Console.Write("→");
                Console.ForegroundColor = ConsoleColor.White;
                Auswahl = 0;
                do
                {
                    switch (Taste.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (Auswahl < 14 && f == false && Buchungsliste.Length - 1 > Auswahl + 15 * Seite) { Auswahl++; }
                            break;
                        case ConsoleKey.UpArrow:
                            if (Auswahl > 0) { Auswahl--; }
                            break;
                    }
                    Console.SetCursorPosition(0, Auswahl + 5); Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, Auswahl + 6); Console.Write("→");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, Auswahl + 7); Console.Write(" ");
                    Taste = Console.ReadKey(true);
                } while (Taste.Key != ConsoleKey.Enter && Taste.Key != ConsoleKey.Escape);
                if (Taste.Key == ConsoleKey.Enter)
                {
                    Auswahl4 = Auswahl + 15 * Seite;

                        if (Buchungsliste[Auswahl4].get_Status() != 'a')
                        {
                            Fehler = true;
                            Auswahl = 0;
                            Buchung_Buchung_Auswahl();
                        }
                        else
                        {
                            Buchung_Abgeschlossen();
                        }
                    
                }
                else if (Taste.Key == ConsoleKey.Escape)
                {
                    Auswahl = 0;
                    Buchung_Buchung_Auswahl();
                }
            }
            else
            {
                if (Taste.Key == ConsoleKey.DownArrow && Seite < SeiteAnzahl)
                {
                    Seite++;
                }
                else if (Taste.Key == ConsoleKey.UpArrow && Seite >= 1)
                {
                    Seite--;
                }
                Buchung_Buchung_Auswahl();
            }
        }
        public void Buchung_Abschluss()// Buchung Aufgenommen Bestätigung
        {
            Console.Clear();
            m.Menü_Buchung_Aufnehmen();
            if (k == false) { cKunde = 'p'; }
            else { cKunde = 'f'; }
            Console.SetCursorPosition(16, 23); Console.ForegroundColor = ConsoleColor.White; Console.Write("Bestätigen Sie mit ");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("diese Buchung!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(3, 5); Console.Write("Hier finden sie nochmal die Einzelheiten zu ihrer Buchung:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(3, 8); Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            if (k == false)
            {
                Console.Write("Privatkunde, " + PrivatKunden[Auswahl2].get_Zuname() + ", " + PrivatKunden[Auswahl2].get_Vorname());
                cKunde = 'p';
            }
            else
            {
                Console.Write("Firmenkunde, " + FirmenKunden[Auswahl2].get_Zuname() + ", " + FirmenKunden[Auswahl2].get_Vorname());
                cKunde = 'f';
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(3, 10); Console.Write("Fahrzeug: ");
            Console.ForegroundColor = ConsoleColor.White;
            if (f == false)
            {
                Console.Write("PKW, " + PKWListe[Auswahl3].get_Fahrzeugtyp() + ", " + PKWListe[Auswahl3].get_Grundpreis() + "EUR, " + PKWListe[Auswahl3].get_Mietpreis() + "EUR/km");
                cFahrzeug = 'p';
            }
            else
            {
                Console.Write("LKW, " + LKWListe[Auswahl3].get_Fahrzeugtyp() + ", " + LKWListe[Auswahl3].get_Grundpreis() + "EUR, " + LKWListe[Auswahl3].get_Mietpreis() + "EUR/km");
                cFahrzeug = 'l';
            }
            Taste = Console.ReadKey();
            if (Taste.Key == ConsoleKey.Enter)
            {
                Array.Resize(ref Buchungsliste, Buchungszähler + 1);
                Buchungsliste[Buchungszähler] = new Buchung('a', cFahrzeug, cKunde, Auswahl3, Auswahl2);
                Buchungszähler++;
                if (f == false)
                {
                    PKWListe[Auswahl3].set_Vermietet(true);
                }
                else
                {
                    LKWListe[Auswahl3].set_Vermietet(true);
                }
            }

        }
        public void Buchung_Abgeschlossen()// Buchung Abgeschlossen Bestätigung
        {
            Console.Clear();
            Console.SetCursorPosition(2, 1); Console.Write("- Buchung beenden");
            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(5, 5); Console.Write("Geben Sie ihren aktuellen Kilometerstand an:");
            Console.ForegroundColor = ConsoleColor.White;
            if (Buchungsliste[Auswahl4].get_Fahrzeugtyp() == 'p')
            {
                Kilometer = Convert.ToInt32(Console.ReadLine());
                if (Kilometer >= PKWListe[Buchungsliste[Auswahl4].get_Fahrzeugnummer()].get_KmStand())
                {
                    PKWListe[Buchungsliste[Auswahl4].get_Fahrzeugnummer()].set_KmStand(Kilometer);
                    Buchungsliste[Auswahl4].set_Status('e');
                }
                else
                {
                    Console.Write("Kilometerstand kann nicht kleiner werden!");
                    Console.ReadKey();
                }
            }
            else
            {
                Kilometer = Convert.ToInt32(Console.ReadLine());
                if (Kilometer >= LKWListe[Buchungsliste[Auswahl4].get_Fahrzeugnummer()].get_KmStand())
                {
                    LKWListe[Buchungsliste[Auswahl4].get_Fahrzeugnummer()].set_KmStand(Kilometer);
                    Buchungsliste[Auswahl4].set_Status('e');
                }
                else
                {
                    Console.Write("Kilometerstand kann nicht kleiner werden!");
                    Console.ReadKey();
                }
            }
        }
        public void Test_Daten()// Methode zum Testen (Auskommentieren im Hauptmenü())
        {
            for (int i = 0; i < 9; i++)
            {
                Array.Resize(ref PrivatKunden, Kundenzaehler + 1);
                PrivatKunden[Kundenzaehler] = new Privatkunden("*", "*", new DateTime(1998, 10, 26), true, true, true);
                Kundenzaehler++;
                Array.Resize(ref FirmenKunden, Kundenzaehler2 + 1);
                FirmenKunden[Kundenzaehler2] = new Firmenkunde("*", "*", new DateTime(1998, 10, 26), true, "GmbH", true);
                Kundenzaehler2++;
                Array.Resize(ref PKWListe, Fahrzeugzahler + 1);
                PKWListe[Fahrzeugzahler] = new PKW(1000, 15.0, 1000, "Combi", true, false, 9, false);
                Fahrzeugzahler++;
                Array.Resize(ref LKWListe, Fahrzeugzahler2 + 1);
                LKWListe[Fahrzeugzahler2] = new LKW(500, 100, 1000, "Schlepper", 100, 100, 1000, true);
                Fahrzeugzahler2++;
                Array.Resize(ref LKWListe, Fahrzeugzahler2 + 1);
                LKWListe[Fahrzeugzahler2] = new LKW(500, 100, 1000, "Tieflader", 100, 100, 1000, true);
                Fahrzeugzahler2++;

            }
            Array.Resize(ref Buchungsliste, Buchungszähler + 1);
            Buchungsliste[Buchungszähler] = new Buchung('a', 'p', 'p', 1, 1);
            Buchungszähler++;
            Array.Resize(ref Buchungsliste, Buchungszähler + 1);
            Buchungsliste[Buchungszähler] = new Buchung('a', 'l', 'f', 1, 1);
            Buchungszähler++;
            Array.Resize(ref Buchungsliste, Buchungszähler + 1);
            Buchungsliste[Buchungszähler] = new Buchung('i', 'p', 'p', 1, 1);
            Buchungszähler++;
            Array.Resize(ref Buchungsliste, Buchungszähler + 1);
            Buchungsliste[Buchungszähler] = new Buchung('i', 'l', 'f', 1, 1);
            Buchungszähler++;
            Array.Resize(ref Buchungsliste, Buchungszähler + 1);
            Buchungsliste[Buchungszähler] = new Buchung('a', 'p', 'p', 1, 1);
            Buchungszähler++;
            Array.Resize(ref Buchungsliste, Buchungszähler + 1);
            Buchungsliste[Buchungszähler] = new Buchung('a', 'p', 'p', 1, 1);
            Buchungszähler++;
        }
        public void Speichern_Privatkunden()// Speichern des Privatkunden Arrays
        {
            if (PrivatKunden != null)
            {
                StreamWriter Writer = new StreamWriter(Privatkundenpfad);
                for (int i = 0; i < PrivatKunden.Length; i++)
                {
                    Writer.Write(i);
                    Writer.Write(";");

                    Writer.Write(PrivatKunden[i].get_Vorname());
                    Writer.Write(";");

                    Writer.Write(PrivatKunden[i].get_Zuname());
                    Writer.Write(";");

                    Writer.Write(PrivatKunden[i].get_Gebi().ToShortDateString());
                    Writer.Write(";");

                    Writer.Write(PrivatKunden[i].get_Fuhrerschein());
                    Writer.Write(";");

                    Writer.Write(PrivatKunden[i].get_Mitglied());
                    Writer.WriteLine(";");
                }
                Writer.Close();
            }
        }
        public void Speichern_Firmenkunden()// Speichern des Firmenkunden Arrays
        {
            if (FirmenKunden != null)
            {
                StreamWriter Writer = new StreamWriter(Firmenkundenpfad);
                for (int i = 0; i < FirmenKunden.Length; i++)
                {
                    Writer.Write(i);
                    Writer.Write(";");

                    Writer.Write(FirmenKunden[i].get_Vorname());
                    Writer.Write(";");

                    Writer.Write(FirmenKunden[i].get_Zuname());
                    Writer.Write(";");

                    Writer.Write(FirmenKunden[i].get_Gebi().ToShortDateString());
                    Writer.Write(";");

                    Writer.Write(FirmenKunden[i].get_Fuhrerschein());
                    Writer.Write(";");

                    Writer.Write(FirmenKunden[i].get_Firmenname());
                    Writer.WriteLine(";");
                }
                Writer.Close();
            }
        }
        public void Speichern_PKW()// Speichern des PKW Arrays
        {
            if (PKWListe != null)
            {


                StreamWriter Writer = new StreamWriter(PKWpfad);
                for (int i = 0; i < PKWListe.Length; i++)
                {
                    Writer.Write(i);
                    Writer.Write(";");

                    Writer.Write(PKWListe[i].get_Fahrzeugtyp());
                    Writer.Write(";");

                    Writer.Write(PKWListe[i].get_KmStand());
                    Writer.Write(";");

                    Writer.Write(PKWListe[i].get_Grundpreis());
                    Writer.Write(";");

                    Writer.Write(PKWListe[i].get_Mietpreis());
                    Writer.Write(";");

                    Writer.Write(PKWListe[i].get_Automatik());
                    Writer.Write(";");

                    Writer.Write(PKWListe[i].get_Klimaanlage());
                    Writer.Write(";");

                    Writer.Write(PKWListe[i].get_Sitzplatze());
                    Writer.WriteLine(";");
                }
                Writer.Close();
            }
        }
        public void Speichern_LKW()// Speichern des LKW Array
        {
            if (LKWListe != null)
            {
                StreamWriter Writer = new StreamWriter(LKWpfad);
                for (int i = 0; i < LKWListe.Length; i++)
                {
                    Writer.Write(i);
                    Writer.Write(";");

                    Writer.Write(LKWListe[i].get_Fahrzeugtyp());
                    Writer.Write(";");

                    Writer.Write(LKWListe[i].get_KmStand());
                    Writer.Write(";");

                    Writer.Write(LKWListe[i].get_Grundpreis());
                    Writer.Write(";");

                    Writer.Write(LKWListe[i].get_Mietpreis());
                    Writer.Write(";");

                    Writer.Write(LKWListe[i].get_Ladefläche());
                    Writer.Write(";");

                    Writer.Write(LKWListe[i].get_Ladevolumen());
                    Writer.Write(";");

                    Writer.Write(LKWListe[i].get_Zugewicht());
                    Writer.WriteLine(";");
                }
                Writer.Close();
            }
        }
        public void Speichern_Buchungen()// Speichern des Buchungs Array
        {
            if (Buchungsliste != null)
            {
                StreamWriter Writer = new StreamWriter(Buchungspfad);
                for (int i = 0; i < Buchungsliste.Length; i++)
                {
                    Writer.Write(i);
                    Writer.Write(";");

                    Writer.Write(Buchungsliste[i].get_Status());
                    Writer.Write(";");

                    Writer.Write(Buchungsliste[i].get_Fahrzeugtyp());
                    Writer.Write(";");

                    Writer.Write(Buchungsliste[i].get_Fahrzeugnummer());
                    Writer.Write(";");

                    Writer.Write(Buchungsliste[i].get_Kundenart());
                    Writer.Write(";");

                    Writer.Write(Buchungsliste[i].get_Kundennummer());
                    Writer.WriteLine(";");

                }
                Writer.Close();
            }
        }
    }
}
