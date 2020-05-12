using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace CarShopDLLProject
{
    public class GeneralUtilities
    {
        #region GeneralUtilities
        public GeneralUtilities() { }
        /// <summary>
        /// Select a path. If not set, the programs have the bin/debug default directory
        /// </summary>
        /// <param name="fbd"> Folder Browser Dialog </param>
        /// <returns></returns>
        public string SelectPath(FolderBrowserDialog fbd)
        {
            string path = string.Empty;

            if (fbd.ShowDialog() == DialogResult.OK) path = fbd.SelectedPath;
            else path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data";

            return path;
        }

        /// <summary>
        /// Create the output file name string
        /// </summary>
        /// <returns></returns>
        public string OutputFileName(string OutputFileDirectory, string fileExtension)
        {
            var datetime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_");

            string fileFullname = Path.Combine(OutputFileDirectory, $"Output.{fileExtension}");

            if (File.Exists(fileFullname))
                fileFullname = Path.Combine(OutputFileDirectory, $"Output_{datetime}.{fileExtension}");

            return fileFullname;
        }
        #endregion
    }

    public class ErrorProviderUtilities
    {
        #region ErrorProviderUtilities
        public ErrorProviderUtilities() { }
        /// <summary>
        /// Set an Error
        /// </summary>
        /// <param name="error"> Error Provider </param>
        /// <param name="control"> The control where the error must be set </param>
        /// <param name="msg"> Error message </param>
        public void setError(ErrorProvider error, Control control, string msg) { error.SetError(control, msg); }
        /// <summary>
        /// Remove an Error
        /// </summary>
        /// <param name="error"> Error Provider </param>
        /// <param name="control"> The control where the error must be removed </param>
        public void resetError(ErrorProvider error, Control control) { error.SetError(control, string.Empty); }
        #endregion
    }

    public class TestModel
    {
        private string brand;
        public TestModel(string brand, string model, string color, string displacement, string powerKw, string matriculation, string isUsed, string isKm0, string kmDone, string price, string special)
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
            Special = special;
        }

        public string Brand { get => brand.ToUpper(); set => brand = value; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Displacement { get; set; }
        public string PowerKw { get; set; }
        public string Matriculation { get; set; }
        public string IsUsed { get; set; }
        public string IsKm0 { get; set; }
        public string KmDone { get; set; }
        public string Price { get; set; }
        public string Special { get; set; }
    }
}
