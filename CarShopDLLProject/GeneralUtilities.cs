#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
#endregion

namespace CarShopDLLProject
{
    public class GeneralUtilities
    {
        #region GeneralUtilities
        public GeneralUtilities() { }
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
}
