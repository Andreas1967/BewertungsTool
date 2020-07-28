using System;

namespace BewerbungsWertung //könnte man auch alles zu einer klassischen, umfassenden Nutzwertanalyse umbauen...
   
{
    class Program
    {
        static void Main(string[] args)
        {
            Nutzwert Andreas = new Nutzwert();

            Andreas.erläuternTool();
            Andreas.erstelleAnzahlKriterien();
            Andreas.durchlaufeAbfrage(Nutzwert.AnzahlKriterien);
            Andreas.fasseZusammen();
            Andreas.zeigeZwischenErgebnis();
            Andreas.schlüsselDerBewertung();
            Console.ReadKey(true);
        }
    }
}


