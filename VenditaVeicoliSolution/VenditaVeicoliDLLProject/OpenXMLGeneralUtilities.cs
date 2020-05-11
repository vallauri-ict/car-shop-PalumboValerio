using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace VenditaVeicoliDLLProject
{
    public class OpenXMLGeneralUtilities
    {
        public static string SelectPath(FolderBrowserDialog fbd)
        {
            string path = string.Empty;

            if (fbd.ShowDialog() == DialogResult.OK)
                path = fbd.SelectedPath;

            return path;
        }

        public static string OutputFileName(string OutputFileDirectory, string fileExtension)
        {
            var datetime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_");

            string fileFullname = Path.Combine(OutputFileDirectory, $"Output.{fileExtension}");

            if (File.Exists(fileFullname))
                fileFullname = Path.Combine(OutputFileDirectory, $"Output_{datetime}.{fileExtension}");

            return fileFullname;
        }
    }
}
