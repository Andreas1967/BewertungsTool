using System;

namespace BewerbungsWertung //könnte man auch alles zu einer klassichen, umfassenden Nutzwertanalyse umbauen...
   
{
    class Nutzwert
    {
        public struct Eigenschaft
        {
            public string Bezeichnung;
            public int Gewichtung;
            public int Note;

        }

        int length;
        Eigenschaft[] Eigenschaften;
        Exception meineException;
        bool hatGeklappt = true;


        public void Erstellen()
        {

            int eingabeGewichtung = 0, eingabeNote = 0;
            int restProzent = 100;
            //double zwischenergebnis = 0, rechnung = 0, ergebnis = 0;
            Console.WriteLine( "\tLieber Nutzer!\n" +
                "\tDieses Tool können Sie nutzen, um Ihren Bewerber nach eigenen Kriterien zu bewerten. \n" +
                "\n\tSie werden zunächst befragt, wie viele Eigenschaften bewertet werden sollen,\n\t" +
                "anschließend führt Sie das Menü weiter und Sie können die entsprechende Eigenschaft eingeben,\n\tdazu noch den Stellenwert im Verhältnis zu allen Eigenschaften und als letztes geben Sie die Bewertung ab,\n\tinwiefern der Bewerber diese Eigenschaft erfüllt.\n\t" +
                "In der Ausgabe erhalten Sie eine Zusammenfassung aller Werte und eine Empfehlung entsprechend der Bewertungsliste.\n\tViel Vergnügen!\n");

            Console.WriteLine("\tBitte gegben Sie ein, wie viele Bewerberkriterien Sie bewerten wollen: \n\n\n\t"); //wie bekomme ich einen eingerückte Eingabezeile hin?
            do
            {
                try
                {
                    length = Convert.ToInt32(Console.ReadLine());
                    Eigenschaften = new Eigenschaft[length];
                    hatGeklappt = true;
                }
                catch (Exception ex)
                {
                    hatGeklappt = false;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\tSie haben sich leider verschrieben , bitte geben Sie eine Ganzzahl ein:");
                }
            } while (hatGeklappt == false);

            for (int i = 0; i < length; i++)
            {
                #region Bezeichnung


                if (i == 0)
                {
                    Console.WriteLine("\tBeginnen wir mit dem " + (i + 1) + ". Bewertungskriterium:\n\t");
                }
                else
                {
                    Console.WriteLine("\tWeiter geht es mit dem " + (i + 1) + ". Bewertungskriterium:\n\t");
                }
                Eigenschaften[i].Bezeichnung = Console.ReadLine();
                Console.WriteLine("\tOK. Die " + (i + 1) + " Eigenschaft nennen Sie " + Eigenschaften[i].Bezeichnung + ".\n\t");

                #endregion

                #region Gewichtung

                Console.WriteLine("\tNun geben Sie bitte ein, wie wichtig Ihnen " + Eigenschaften[i].Bezeichnung + " als Bewertungskriterium ist.\n\n\tSie können noch " + restProzent + "% vergeben:\n\t");

                do
                {
                    try
                    {
                        eingabeGewichtung = Convert.ToInt32(Console.ReadLine());
                        hatGeklappt = true;
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine(ex.Message);

                        meineException = ex;
                        Console.WriteLine("\tBitte eine Zahl zwischen 0 und  " + restProzent + " eingeben.\n\t\n");

                        hatGeklappt = false;
                    }
                    if (eingabeGewichtung >= 0 && eingabeGewichtung <= restProzent)
                    {

                        Eigenschaften[i].Gewichtung = eingabeGewichtung;
                    }
                    else
                    {
                        hatGeklappt = false;
                        Console.WriteLine("\tBitte eine Zahl zwischen 0 und  " + restProzent + " eingeben.\n\t");

                        
                    }


                } while (hatGeklappt == false);

                restProzent = restProzent - eingabeGewichtung;

                Console.WriteLine("\tSuper gemacht! Und nun geht es weiter...\n");
                if (i > 0 && i < 2)
                {
                    Console.WriteLine("\tNun sind Sie ja schon fast Eingabeprofi!");
                }
                else if (i > 2)
                {
                    Console.WriteLine("\tWeiter so!");
                }

                #endregion
                #region Note

                Console.WriteLine("\tNun können Sie 0-10 Punkte vergeben, um das Kriterium  -" + Eigenschaften[i].Bezeichnung +
                    "- des Bewerbers zu bewerten. " +
                    "\n\n\t 0 Punkte steht für unterirdisch schlecht" +
                    "\n\n\t 10 Punkte erhält ein Überflieger in seinem Gebiet");

                if (i > 0)
                {
                    Console.WriteLine("Bitte 0 bis 10 Punkte vergeben:");
                }

                do
                {
                    try
                    {
                        eingabeNote = Convert.ToInt32(Console.ReadLine());

                        hatGeklappt = true;
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine(ex.Message);

                        meineException = ex;
                        if (meineException != null)
                        {
                            hatGeklappt = false;
                            Console.WriteLine("\tBitte eine Punktzahl zwischen 0 und 10 eingeben.\n\t\n");
                        }
                    }
                    if (eingabeNote >= 0 && eingabeNote <= 10)
                    {
                        Eigenschaften[i].Note = eingabeNote;
                    }
                    else
                    {
                        hatGeklappt = false;
                        Console.WriteLine("\tBitte eine Punktzahl zwischen 0 und 10 eingeben.\n\t\n");
                    }




                } while (!hatGeklappt);
                #endregion

            }
        }
        #region drucken
        public void Drucken()
        {
            Console.WriteLine("\tIhre Bewertungen:");
            Console.WriteLine("\t-----------------");
            Console.WriteLine("\t{0, -20} {1, -20} {2, -20}\n", "Bezeichnung", "Gewichtung", "Note");
            for (int i = 0; i < length; i++)
            {
                
                Console.WriteLine("\t{0, -20} {1, -20} {2, -20}\n",
                    Eigenschaften[i].Bezeichnung,
                    Eigenschaften[i].Gewichtung,
                    Eigenschaften[i].Note);
            }
        }
        #endregion

        int rechnung = 0, ergebnis = 0;
        int maxDurchschittPunktezahl;
        double prozentErgebnis;
        int anzahlKriterien = 1;

        public void ZwischenErgebnis()
        {
            anzahlKriterien = length;

            for (int i = 0; i < length; i++)
            {
                rechnung = Eigenschaften[i].Gewichtung * Eigenschaften[i].Note;
                ergebnis = (ergebnis + rechnung);
            }
            ergebnis = ergebnis / anzahlKriterien;

            maxDurchschittPunktezahl = 100 * 10 / length;
            prozentErgebnis = ergebnis * 100 / maxDurchschittPunktezahl;
            Console.WriteLine("\n\tDie maximal erreichbare Punktzahl liegt bei: \t" + maxDurchschittPunktezahl + "\n");
            Console.WriteLine("\n\tDie Punktezahl des Bewerbers liegt bei: \t" + ergebnis + " oder " + prozentErgebnis + "%.\n");
        }

        public void schlüssel()
        {
            if (prozentErgebnis < 50)
            {
                Console.WriteLine("\n\tDas passt wohl nicht. Absagen ist wohl die richtige Lösung.");
            }
            else if (prozentErgebnis < 60)
            {
                Console.WriteLine("\n\tDa kann man ja noch mal drüber schauen. Vielleicht verdient dieswer Mensch eine Chance?");
            }
            else if (prozentErgebnis < 85)
            {
                Console.WriteLine("\n\tJuhu, der Praktikant scheint zu uns zu passen!");
            }
            else if (prozentErgebnis > 85)
            {
                Console.WriteLine("\n\tZu gut um wahr zu sein! Oder? Aber wenn, eine Sensation!");
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Nutzwert Andreas = new Nutzwert();

            Andreas.Erstellen();
            Andreas.Drucken();
            Andreas.ZwischenErgebnis();
            Andreas.schlüssel();
            Console.ReadKey(true);
        }
    }
}


