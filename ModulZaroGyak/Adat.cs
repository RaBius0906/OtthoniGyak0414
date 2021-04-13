using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulZaroGyak
{
    class Adat
    {
        //Azonosito,Nev,Nem,Hajszin,Kor,Magassag
        public int Azonosito { get; set; }
        public string Nev { get; set; }
        public string getNev() { return Nev; }
        public string Nem { get; set; }
        public string Hajszin { get; set; }
        public string getHajszin() { return Hajszin; }
        public int Kor { get; set; }
        public double Magassag { get; set; }

        public Adat(string sor)
        {
            string[] s = sor.Split(',');
            this.Azonosito = int.Parse(s[0]);
            this.Nev = s[1];
            this.Nem = s[2];
            this.Hajszin = s[3];
            this.Kor = int.Parse(s[4]);
            this.Magassag = double.Parse(s[5]);
        }

        //public override string ToString()
        //{
        //    return Nev;
        //}

    }
}
