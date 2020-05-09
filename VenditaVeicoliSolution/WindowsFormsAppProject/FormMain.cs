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

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        public SerializableBindingList<Veicoli> listaVeicoli; // La BindingList sente i cambiamenti durante il codice
        public FormMain()
        {
            InitializeComponent();
            listaVeicoli = new SerializableBindingList<Veicoli>();
            listBoxVeicoli.DataSource = listaVeicoli;
        }

        /*private void CaricaDatiDiTest()
        {
            Moto m = new Moto();
            Auto a = new Auto();


            listaVeicoli.Add(m);
            m = new Moto("Honda", "Tsunami", "Rosso", 1000, 120, DateTime.Now, false, false, 0, "Quintino");
            listaVeicoli.Add(m);
            listaVeicoli.Add(a);
            a = new Auto("Fiat", "Panda", "Nero", 1000, 75.20, DateTime.Now, false, false, 0, 8);
            listaVeicoli.Add(a);
        }*/

        private void tsmNuovo_Click(object sender, EventArgs e)
        {
            FormDialogAggiungiVeicolo dialogAggiungi = new FormDialogAggiungiVeicolo(this);
            dialogAggiungi.ShowDialog();
        }

        private void tsbApri_Click(object sender, EventArgs e)
        {
            Utils.ParseJsonToObject(@".\Veicoli.json", listaVeicoli);
        }

        private void tsbSalva_Click(object sender, EventArgs e)
        {
            Utils.SerializeToJson(listaVeicoli, @".\Veicoli.json");
        }

        private void tsbStampa_Click(object sender, EventArgs e)
        {
            if (listaVeicoli.Count > 0)
            {
                string homepagePath = @".\www\index.html";
                Utils.CreateHtml(listaVeicoli, homepagePath);
                Process.Start(homepagePath);
            }
            else
                MessageBox.Show("Inserisci almeno un veicolo prima di visualizzare!");
        }
    }
}
