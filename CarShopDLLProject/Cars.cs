#region Using
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace CarShopDLLProject
{
    public class Cars : Vehicles
    {
        #region Cars
        public Cars() : base("Fiat", "Panda", "Nero", 1000, 75.20, DateTime.Now, false, false, 321567, 30000, "noImage.png")
        {
            NumAirbag = 6;
        }
        public Cars(string brand, string model, string color, int displacement, double powerKw, 
            DateTime matriculation, bool isUsed, bool isKm0, int kmDone, double price, string img, int numAirbag) 
            : base(brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmDone, price, img)
        {
            NumAirbag = numAirbag;
        }

        public int NumAirbag { get; set; }

        public override string ToString() { return $"Auto: {base.ToString()} - {NumAirbag} Airbag - {Price} €"; }
        #endregion
    }
}
