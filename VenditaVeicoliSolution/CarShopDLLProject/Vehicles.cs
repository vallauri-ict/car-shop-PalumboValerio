#region Using
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace CarShopDLLProject
{
    public abstract class Vehicles
    {
        #region Vehicles
        private string brand;
        public Vehicles(string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, double price)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Displacement = displacement;
            PowerKw = powerKw;
            Matriculation = matriculation;
            IsUsed = isUsed;
            IsKm0 = isKm0;
            KmDone = kmDone;
            Price = price;
        }

        public string Brand { get => brand.ToUpper(); set => brand = value; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Displacement { get; set; }
        public double PowerKw { get; set; }
        public DateTime Matriculation { get; set; }
        public bool IsUsed { get; set; }
        public bool IsKm0 { get; set; }
        public int KmDone { get; set; }
        public double Price { get; set; }

        public override string ToString() { return $" {Brand} - Modello: {Model} ({Matriculation.Year})"; }
        #endregion
    }
}
