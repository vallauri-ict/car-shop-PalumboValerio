using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaVeicoliDLLProject
{
    public class Auto : Veicoli
    {
        private int numAirbag;
        public Auto() : base("Fiat", "Panda", "Nero", 1000, 75.20, DateTime.Now, false, false, 0) 
        {
            NumAirbag = 6;
        }
        public Auto(string marca, string modello, string colore, int cilindrata, double potenzaKw, 
            DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi, int numAirbag) : base(marca, modello, colore, 
                cilindrata, potenzaKw, immatricolazione, isUsato, isKmZero, kmPercorsi)
        {
            NumAirbag = numAirbag;
        }

        public int NumAirbag { get => numAirbag; set => numAirbag = value; }

        public override string ToString() { return $"Auto: {base.ToString()} - {NumAirbag} Airbag"; }
    }
}
