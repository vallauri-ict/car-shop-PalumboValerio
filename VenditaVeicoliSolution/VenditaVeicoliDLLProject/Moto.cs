﻿using System;

namespace VenditaVeicoliDLLProject
{
    public class Moto : Veicoli
    {
        private string marcaSella;
        public Moto() : base("Ducati", "Squalo", "Nero", 1000, 75.20, DateTime.Now, false, false, 0) 
        {
            MarcaSella = "Cavallino";
        }

        public Moto(string marca, string modello, string colore, int cilindrata, double potenzaKw,
            DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi, string marcaSella) : base(marca, modello, colore,
                cilindrata, potenzaKw, immatricolazione, isUsato, isKmZero, kmPercorsi)
        {
            MarcaSella = marcaSella;
        }

        public string MarcaSella { get => marcaSella; set => marcaSella = value; }

        public override string ToString() { return $"Moto: {base.ToString()} - Sella {MarcaSella}"; }
    }
}
