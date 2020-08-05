using System;

namespace BewerbungsWertung //könnte man auch alles zu einer klassischen, umfassenden Nutzwertanalyse umbauen...

{
    class Program
    {
        static void Main(string[] args)
        {
            Nutzwert Andreas = new Nutzwert();
            DateiSpeichern DokErstellen = new DateiSpeichern();
            /*Andreas.erläuternTool();
            Andreas.erstelleAnzahlKriterien();
            Andreas.durchlaufeAbfrage(Nutzwert.AnzahlKriterien);
            Andreas.fasseZusammen();
            Andreas.zeigeZwischenErgebnis();
            Andreas.schlüsselDerBewertung();*/
            DokErstellen.DateiNamen();
            DokErstellen.DateiPfaderstellen();
            DokErstellen.DateiAbspeichern();
            Console.ReadKey(true);
        }
    }
}


