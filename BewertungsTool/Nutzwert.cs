using System;
namespace BewerbungsWertung
{
    public class Nutzwert
    {

        BewertungsKriterium[] Eigenschaften;
        public static int AnzahlKriterien;
        public struct BewertungsKriterium
        {
            public string Bezeichnung;
            public int Gewichtung;
            public int Punkte;
        }

        public void erläuternTool()
        {
            Console.WriteLine("\tLieber Nutzer!\n" +
                "\tDieses Tool können Sie nutzen, um Ihren Bewerber nach eigenen Kriterien zu bewerten. \n" +
                "\n\tSie werden zunächst befragt, wie viele Eigenschaften bewertet werden sollen," +
                "\n\tanschließend führt Sie das Menü weiter und Sie können die entsprechende Eigenschaft eingeben," +
                "\n\tdazu noch den Stellenwert im Verhältnis zu allen Eigenschaften und als letztes geben Sie die Bewertung ab," +
                "\n\tinwiefern der Bewerber diese Eigenschaft erfüllt." +
                "\n\tIn der Ausgabe erhalten Sie eine Zusammenfassung aller Werte und eine Empfehlung entsprechend der Bewertungsliste." +
                "\n\tViel Vergnügen!\n");
        }

        public int erstelleAnzahlKriterien()
        {
            Console.WriteLine("\tBitte gegben Sie ein, wie viele Bewerberkriterien Sie bewerten wollen: \n\n\n\t");
            bool hatGeklappt = false;
            do
            {
                try
                {
                    AnzahlKriterien = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\tSie haben sich leider verschrieben, bitte geben Sie eine Ganzzahl ein:");
                    continue;
                }
                Eigenschaften = new BewertungsKriterium[AnzahlKriterien];
                hatGeklappt = true;
            } while (hatGeklappt == false);
            return AnzahlKriterien;
        }

        public void durchlaufeAbfrage(int AnzahlKriterien)
        {

            for (int index = 0; index < AnzahlKriterien; index++)
            {
                erstelleBewertungsKriterium(index);
                erstelleGewichtungDesKriteriums(index, AnzahlKriterien);
                erstellePunktzahlFürKriterium(index);
            }
        }

        public string erstelleBewertungsKriterium(int index)
        {
            Console.WriteLine("Bitte geben Sie das {0}. Bewertungskriterium ein:", index + 1);
            Eigenschaften[index].Bezeichnung = Console.ReadLine();
            Console.WriteLine("\tDanke. Die {0}. Eigenschaft nennen Sie {1}.", index + 1, Eigenschaften[index].Bezeichnung + ".\n\t");
            return Eigenschaften[index].Bezeichnung;
        }

        int fehlerFangenGewichtung(bool hatGeklappt, int index, int restProzent)
        {
            do
            {
                try
                {
                    Eigenschaften[index].Gewichtung = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Sie haben sich verschrieben, bitte geben Sie eine Ganzzahl ein:");
                    continue;
                }
                if (Eigenschaften[index].Gewichtung >= 0 && Eigenschaften[index].Gewichtung <= restProzent)
                {
                    hatGeklappt = true;
                }
                else
                {
                    Console.WriteLine("Bitte eine Zahl zwischen 0 und {0} eingeben:", restProzent);
                }
            } while (hatGeklappt == false);
            return restProzent;
        }

        public void erstelleGewichtungDesKriteriums(int index, int AnzahlKriterien)
        {
            int restProzent = 100;
            bool hatGeklappt = false;
            if (index == 0)
            {
                Console.WriteLine("\tGeben Sie bitte ein, wie wichtig Ihnen {0} als Bewertungskriterium ist.\n\n\tSie können noch  {1} % vergeben:\n\t", Eigenschaften[index].Bezeichnung, restProzent);
                fehlerFangenGewichtung(hatGeklappt, index, restProzent);
            }
            for (int i = 0; i < AnzahlKriterien; i++)
            {
                restProzent = restProzent - Eigenschaften[i].Gewichtung;
            }

            if (index > 0 && index < AnzahlKriterien - 1)
            {
                Console.WriteLine("\tGeben Sie bitte ein, wie wichtig Ihnen {0} als Bewertungskriterium ist.\n\n\tSie können noch  {1} % vergeben:\n\t", Eigenschaften[index].Bezeichnung, restProzent);
                fehlerFangenGewichtung(hatGeklappt, index, restProzent);
            }
            else if (index == AnzahlKriterien - 1)
            {
                Eigenschaften[index].Gewichtung = restProzent;
                Console.WriteLine("Für die letzte Eigenschaft vergeben Sie automatisch die verbleibenden Anteile von {0} Prozent.", restProzent);
                Eigenschaften[index].Gewichtung = restProzent;
            }


        }

        public int erstellePunktzahlFürKriterium(int index)
        {
            Console.WriteLine("Bewerten Sie das Kriterium {0} mit einer Punktzahl von 1 (absolut schlecht) bis 10 (fantastisch):", index + 1);
            bool hatGeklappt = false;
            do
            {
                try
                {
                    Eigenschaften[index].Punkte = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Die Eingabe war falsch. Bitte eine Ganzzahl von 1 bis einschließlich 10 eingeben:");
                    continue;
                }
                if (Eigenschaften[index].Punkte > 0 && Eigenschaften[index].Punkte < 11)
                {
                    hatGeklappt = true;
                }
                else
                {
                    Console.WriteLine("Die Zahl war zu klein oder zu groß, bitte eine Ganzzahl von 1 bis einschließlich 10 eingeben:");
                }
            } while (hatGeklappt == false);
            return Eigenschaften[index].Punkte;
        }

        public void fasseZusammen()
        {
            Console.WriteLine("\tIhre Bewertungen:");
            Console.WriteLine("\t-----------------");
            Console.WriteLine("\t{0, -20} {1, -20} {2, -20}\n", "Bezeichnung", "Gewichtung", "Note");
            for (int i = 0; i < AnzahlKriterien; i++)
            {
                Console.WriteLine("\t{0, -20} {1, -20} {2, -20}",
                    Eigenschaften[i].Bezeichnung,
                    Eigenschaften[i].Gewichtung,
                    Eigenschaften[i].Punkte);
            }
        }

        int rechnung = 0, ergebnis = 0;
        int maxDurchschittPunktezahl;
        double prozentErgebnis;


        public void zeigeZwischenErgebnis()
        {
            for (int i = 0; i < AnzahlKriterien; i++)
            {
                rechnung = Eigenschaften[i].Gewichtung * Eigenschaften[i].Punkte;
                ergebnis = (ergebnis + rechnung);
            }
            ergebnis = ergebnis / AnzahlKriterien;

            maxDurchschittPunktezahl = 100 * 10 / AnzahlKriterien;
            prozentErgebnis = ergebnis * 100 / maxDurchschittPunktezahl;
            Console.WriteLine("\n\tDie maximal erreichbare Punktzahl liegt bei: {0}\n", maxDurchschittPunktezahl);
            Console.WriteLine("\n\tDer Bewerber hat {0} Punkte erreicht, was {1} Prozent der möglichen Punktzahl entspricht.\n", ergebnis, prozentErgebnis);
        }

        public void schlüsselDerBewertung()
        {
            if (prozentErgebnis < 50)
            {
                Console.WriteLine("\n\tDas passt wohl nicht. Absagen ist wohl die richtige Lösung.");
            }
            else if (prozentErgebnis < 60)
            {
                Console.WriteLine("\n\tDa kann man ja noch mal drüber schauen. Vielleicht verdient dieser Mensch eine Chance?");
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
}
