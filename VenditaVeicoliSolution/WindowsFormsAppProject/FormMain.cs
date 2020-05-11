#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarShopDLLProject;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
#endregion

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        #region Initializations
        public string jsonFilePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\Veicoli.json";
        public static string dbFilePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\CarShop.accdb";
        public static string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFilePath}";
        public SerializableBindingList<Veicoli> listaVeicoli; // The BindingList hears the changes during the code
        public FormMain()
        {
            InitializeComponent();
            listaVeicoli = new SerializableBindingList<Veicoli>();
            listBoxVeicoli.DataSource = listaVeicoli;
            FormUtilities.UpdateJson(jsonFilePath, connStr);
        }
        #endregion

        #region Events
        private void tsmNuovo_Click(object sender, EventArgs e)
        {
            FormDialogAggiungiModificaVeicolo dialogAggiungi = new FormDialogAggiungiModificaVeicolo(this);
            dialogAggiungi.ShowDialog();
        }

        private void tsbApri_Click(object sender, EventArgs e)
        {
            listaVeicoli.Clear();
            FormUtilities.ParseJsonToObject(jsonFilePath, listaVeicoli);
        }

        private void tsbSalva_Click(object sender, EventArgs e)
        {
            FormUtilities.SerializeToJson(listaVeicoli, jsonFilePath);
            FormUtilities.UpdateDb(listaVeicoli, connStr);
        }

        private void tsbCancella_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sei sicuro di voler eliminare l'elemento selezionato?", "CANCELLA VEICOLO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                listaVeicoli.RemoveAt(listBoxVeicoli.SelectedIndex);
        }

        private void tsbModifica_Click(object sender, EventArgs e)
        {
            FormDialogAggiungiModificaVeicolo dialogAggiungi = new FormDialogAggiungiModificaVeicolo(this, listBoxVeicoli.SelectedIndex);
            dialogAggiungi.ShowDialog();
            FormUtilities.SerializeToJson(listaVeicoli, jsonFilePath);
            listaVeicoli.Clear();
            FormUtilities.ParseJsonToObject(jsonFilePath, listaVeicoli);
            FormUtilities.UpdateDb(listaVeicoli, connStr);
        }

        private void tsbStampa_Click(object sender, EventArgs e)
        {
            if (listaVeicoli.Count > 0)
            {
                string homepagePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\www\\index.html";
                FormUtilities.CreateHtml(listaVeicoli, homepagePath);
                Process.Start(homepagePath);
            }
            else
                MessageBox.Show("Inserisci almeno un veicolo prima di visualizzare!");
        }
        #endregion

        private void tsbWord_Click(object sender, EventArgs e)
        {
            //string filepath = OpenXmlGeneralUtilities.OutputFileName(OpenXmlGeneralUtilities.SelectPath(fbd), "docx");

            /*using (WordprocessingDocument doc = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
            {
            }*/
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
