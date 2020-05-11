using System;

namespace CarShopDLLProject
{
    public class Motorbikes : Vehicles
    {
        #region Motorbikes
        public Motorbikes() : base("Ducati", "Squalo", "Nero", 1000, 75.20, DateTime.Now, false, false, 500012, 0) 
        {
            SaddleBrand = "Cavallino";
        }

        public Motorbikes(string brand, string model, string color, int displacement, double powerKw,
            DateTime matriculation, bool isUsed, bool isKm0, int kmDone, double price, string saddleBrand)
            : base(brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmDone, price)
        {
            SaddleBrand = saddleBrand;
        }

        public string SaddleBrand { get; set; }

        public override string ToString() { return $"Moto: {base.ToString()} - Sella {SaddleBrand} - {Price} €"; }
        #endregion
    }
}
