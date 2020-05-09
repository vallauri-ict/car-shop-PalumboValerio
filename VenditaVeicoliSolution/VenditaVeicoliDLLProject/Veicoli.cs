﻿using System;
using System.Collections.Generic;
using System.Text;
//using System.Xml.Serialization;

namespace VenditaVeicoliDLLProject
{
    public abstract class Veicoli
    {
        #region Fields
        private string marca;
        private string modello;
        private string colore;
        private int cilindrata;
        private double potenzaKw;
        private DateTime immatricolazione;
        private bool isUsato;
        private bool isKmZero;
        private int kmPercorsi;
        #endregion

        public Veicoli(string marca, string modello, string colore, int cilindrata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi)
        {
            Marca = marca;
            Modello = modello;
            Colore = colore;
            Cilindrata = cilindrata;
            PotenzaKw = potenzaKw;
            Immatricolazione = immatricolazione;
            IsUsato = isUsato;
            IsKmZero = isKmZero;
            KmPercorsi = kmPercorsi;
        }

        public string Marca { get => marca.ToUpper(); set => marca = value; }
        public string Modello { get => modello; set => modello = value; }
        public string Colore { get => colore; set => colore = value; }
        public int Cilindrata { get => cilindrata; set => cilindrata = value; }
        public double PotenzaKw { get => potenzaKw; set => potenzaKw = value; }
        public DateTime Immatricolazione { get => immatricolazione; set => immatricolazione = value; }
        public bool IsUsato { get => isUsato; set => isUsato = value; }
        public bool IsKmZero { get => isKmZero; set => isKmZero = value; }
        public int KmPercorsi { get => kmPercorsi; set => kmPercorsi = value; }

        public override string ToString() { return $" {Marca} - Modello: {Modello} ({Immatricolazione.Year})"; }
    }
}
