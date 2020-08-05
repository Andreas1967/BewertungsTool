using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BewerbungsWertung
{
    class DateiSpeichern
    {
        //Nutzwert zusammenfassung = new Nutzwert();
        public string dateiPfad { get; private set; }
        public string neueDateiName { get; private set; }
        public string endung = ".txt";

        public DateiSpeichern(string neueDateiName, string endung)
        {
            this.neueDateiName = neueDateiName;
            this.endung = endung;
        }

        public DateiSpeichern()
        {
        }

        public void DateiNamen()
        {
            Console.WriteLine("\tBitte geben Sie ein, unter welchem Namen die Datei mit den Bewertungsergebnissen gespeichert werden soll:");
            neueDateiName = Console.ReadLine();
            Console.WriteLine(neueDateiName);
        }

        public void DateiPfaderstellen()
        {
            Console.WriteLine("\tDie Datei wird standardmäßig auf dem Desktop/Schreibtisch abgespeichert.\n");
            Console.WriteLine("\tMöchten Sie den Speicherort ändern? [J] [N]:\n");
            string eingabe = Console.ReadLine();
            eingabe = eingabe.ToUpper();
            dateiPfad = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//gibt den speziellen Pfad des Users zurück(Desktop)
            switch (eingabe)

            {
                case "J":
                    Console.WriteLine("\tBitte geben Sie ein, wo Sie  die Datei speichern möchten!\n");
                    string dateipfad = Console.ReadLine();
                    if (!Directory.Exists(dateipfad))
                        Directory.CreateDirectory(dateipfad);
                    break;
                case "N":
                    if (!Directory.Exists(dateiPfad)) 
                        Directory.CreateDirectory(dateiPfad);
                    break;
                default:
                    Console.WriteLine("\tDie Eingabe war nicht richtig. Bitte ein [J]a oder [N]ein eingeben:\n");
                    break;
            }
            Console.WriteLine(dateiPfad);
        }

        public void DateiAbspeichern()
        {

            File.WriteAllText(dateiPfad + "\\" + neueDateiName, "TextReader der bewertung");
        }
    }
}
