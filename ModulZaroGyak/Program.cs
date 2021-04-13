using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulZaroGyak
{
    class Program
    {
        public static int i;

        static void Main(string[] args)
        {
            // Fájlbeolvasás
            string[] sorok = File.ReadAllLines("Book1.csv");
            List<Adat> adatok = new List<Adat>();
            foreach (string sor in sorok.Skip(1)) 
            {
                adatok.Add(new Adat(sor));
            }

            //Hány adatsor van? --> 7
            int N = adatok.Count;
            Console.WriteLine($"Hány adatsor van? {N} db");

            //Mennyi a csapat teljes összmagassága? --> 11.97
            double osszmagassag = 0;
            foreach (Adat adat in adatok)
            {
                osszmagassag += adat.Magassag;
            }
            Console.WriteLine($"A csapat összmagassága {osszmagassag} m.");

            //Mennyi a lányok összmagassága? --> 6.73
            double lanyOsszmagassag = 0;
            foreach (Adat adat in adatok)
            {
                if (adat.Nem == "lany")
                {
                    lanyOsszmagassag += adat.Magassag;
                }
            }
            Console.WriteLine($"A lányok összmagassága {lanyOsszmagassag} m.");

            //Ki a legidősebb? --> Judit
            int legidosebbIndex = 0;
            for (i = 1; i < N; i++)
            {
                if (adatok[i].Kor > adatok[legidosebbIndex].Kor)
                {
                    legidosebbIndex = i;
                }
            }
            Console.WriteLine($"Ki a legidsősebb? {adatok[legidosebbIndex].Nev}");

            //Mindenki nagykorú? --> igen
            i = 0;
            while (i<N && !(adatok[i].Kor >= 18)) { i++; }
            bool mindenkiNagykoru = i <= N;
            string valasz = mindenkiNagykoru ? "igen" : "nem";
            Console.WriteLine($"Mindenki nagykorú? {valasz}");

            //Az összes lány elmúlt 30 éves? --> nem
            i = 0;
            while (i < N && !(adatok[i].Kor >= 30) && !(adatok[i].Nem == "lany")) { i++; }
            bool mindenLanyIdosebb30 = i >= N;
            string valasz2 = mindenLanyIdosebb30 ? "igen" : "nem";
            Console.WriteLine($"Minden lány elmúlt 30 éves? {valasz2}");

            //Hány féle hajszínű ember van, színek felsorolása?
            HashSet<string> hajszinek = new HashSet<string>();
            foreach (Adat adat in adatok)
            {
                hajszinek.Add(adat.getHajszin());
            }
            Console.WriteLine($"Hajszínek:");

            foreach (string hajszin in hajszinek)
            {
                Console.Write($"{hajszin} ");
            }
            Console.WriteLine();

            //Van szőke hajú ember? --> van
            i = 0;
            while (i < N && !(adatok[i].Hajszin == "szoke")) { i++; }
            bool vanSzoke = i < N;
            string valasz3 = vanSzoke ? "van" : "nincs";
            Console.WriteLine($"Van szőke hajú ember? {valasz3}");

            //Van barna hajú lány? --> van
            i = 0;
            while (i < N && !(adatok[i].Hajszin == "barna") && !(adatok[i].Nem == "lany")) { i++; }
            bool vanBarnaLany = i < N;
            string valasz4 = vanBarnaLany ? "van" : "nincs";
            Console.WriteLine($"Van barna hajú lány? {valasz4}");

            //Melyik hajszínből mennyi van?
            Dictionary<string, int> hajszinDb = new Dictionary<string, int>();
            foreach (Adat adat in adatok)
            {
                string kulcs = adat.Hajszin;
                if (hajszinDb.ContainsKey(kulcs))
                {
                    hajszinDb[kulcs]++;
                }
                else
                {
                    hajszinDb.Add(kulcs, 1);
                }
            }
            Console.WriteLine($"Melyik hajszínből hány darab van a listában?");
            foreach (KeyValuePair<string, int> item in hajszinDb)
            {
                Console.WriteLine($"\t{item.Key}: {item.Value} db");
            }

            //Hány 30 év alatti és hány 30 év feletti ember van? --> alatta 3 , felette 4 
            int Db30alatt = 0;
            int Db30felett = 0;
            foreach (Adat adat in adatok)
            {
                if (adat.Kor < 30)
                {
                    Db30alatt++;
                }
                else
                {
                    Db30felett++;
                }
            }
            Console.WriteLine($"30 év alattiak száma: {Db30alatt} fő \n 30 év felettiek száma: {Db30felett} fő");

            //Irasd ki a 30 év alatti lányokat! --> Eva, Anna
            List<string> lany30alatt = new List<string>();
            foreach (Adat adat in adatok)
            {
                if (adat.Kor < 30 && adat.Nem == "lany")
                {
                    lany30alatt.Add(adat.getNev());
                }
            }
            Console.WriteLine($"A 30 év alatti lányok:");
            foreach (string item in lany30alatt)
            {
                Console.WriteLine($"\t {item} ");
            }
            Console.ReadLine();
        }
    }
}
