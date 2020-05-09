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
using VenditaVeicoliDLLProject;
using System.IO;
using System.Diagnostics;
#endregion

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        #region Initializations
        public SerializableBindingList<Veicoli> listaVeicoli; // The BindingList hears the changes during the code
        public FormMain()
        {
            InitializeComponent();
            listaVeicoli = new SerializableBindingList<Veicoli>();
            listBoxVeicoli.DataSource = listaVeicoli;
        }
        #endregion

        #region Events
        private void tsmNuovo_Click(object sender, EventArgs e)
        {
            FormDialogAggiungiVeicolo dialogAggiungi = new FormDialogAggiungiVeicolo(this);
            dialogAggiungi.ShowDialog();
        }

        private void tsbApri_Click(object sender, EventArgs e)
        {
            listaVeicoli.Clear();
            FormUtilities.ParseJsonToObject(@".\Veicoli.json", listaVeicoli);
        }

        private void tsbSalva_Click(object sender, EventArgs e)
        {
            FormUtilities.SerializeToJson(listaVeicoli, @".\Veicoli.json");
        }

        private void tsbCancella_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sei sicuro di voler eliminare l'elemento selezionato?", "CANCELLA VEICOLO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                listaVeicoli.RemoveAt(listBoxVeicoli.SelectedIndex);
        }

        private void tsbStampa_Click(object sender, EventArgs e)
        {
            if (listaVeicoli.Count > 0)
            {
                string homepagePath = @".\www\index.html";
                FormUtilities.CreateHtml(listaVeicoli, homepagePath);
                Process.Start(homepagePath);
            }
            else
                MessageBox.Show("Inserisci almeno un veicolo prima di visualizzare!");
        }
        #endregion
    }
}
