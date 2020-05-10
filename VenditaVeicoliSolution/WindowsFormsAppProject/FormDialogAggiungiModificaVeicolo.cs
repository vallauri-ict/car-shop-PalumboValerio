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
#endregion

namespace WindowsFormsAppProject
{
    public partial class FormDialogAggiungiModificaVeicolo : Form
    {
        #region Declaration
        List<Control> controls;
        string veicolo;
        FormMain formMain;
        private int selectedIndex;
        #endregion

        #region Form
        public FormDialogAggiungiModificaVeicolo(FormMain formMain)
        {
            InitializeComponent();
            Control[] aus = { txtMarca, txtModello, txtColore, nmuCilindrata, nmuPotenza, nmuKmPercorsi, nmuPrezzo, nmuAirbag };
            controls = new List<Control>(aus);
            this.formMain = formMain;
            veicolo = "AUTO";

            Text = "AGGIUNGI VEICOLO";
            btnAggiungiModifica.Text = "AGGIUNGI";
            cmbTipoVeicolo.Enabled = true;
            cmbTipoVeicolo.SelectedIndex = 0;
            lblMarcaSella.Location = lblNAirbag.Location;
            txtMarcaSella.Location = nmuAirbag.Location;
            dtpImmatricolazione.MaxDate = DateTime.Today;
            dtpImmatricolazione.Value = DateTime.Today;
            txtMarcaSella.Visible = lblMarcaSella.Visible = false;
        }

        public FormDialogAggiungiModificaVeicolo(FormMain formMain, int selectedIndex) : this(formMain)
        {
            Text = "MODIFICA VEICOLO";
            cmbTipoVeicolo.Enabled = false;
            txtMarca.Text = formMain.listaVeicoli[selectedIndex].Marca;
            txtModello.Text = formMain.listaVeicoli[selectedIndex].Modello;
            txtColore.Text = formMain.listaVeicoli[selectedIndex].Colore;
            nmuCilindrata.Value = formMain.listaVeicoli[selectedIndex].Cilindrata;
            nmuPotenza.Value = Convert.ToDecimal(formMain.listaVeicoli[selectedIndex].PotenzaKw);
            dtpImmatricolazione.Value = formMain.listaVeicoli[selectedIndex].Immatricolazione;
            chkUsato.Checked = formMain.listaVeicoli[selectedIndex].IsUsato;
            chkKmZero.Checked = formMain.listaVeicoli[selectedIndex].IsKmZero;
            nmuKmPercorsi.Value = formMain.listaVeicoli[selectedIndex].KmPercorsi;
            nmuPrezzo.Value = Convert.ToDecimal(formMain.listaVeicoli[selectedIndex].Prezzo);
            if (formMain.listaVeicoli[selectedIndex] is Moto)
            {
                cmbTipoVeicolo.SelectedIndex = 1;
                txtMarcaSella.Text = (formMain.listaVeicoli[selectedIndex] as Moto).MarcaSella;
            }
            else
                nmuAirbag.Value= (formMain.listaVeicoli[selectedIndex] as Auto).NumAirbag;
            btnAggiungiModifica.Text = "MODIFICA";
            this.selectedIndex = selectedIndex;
        }
        #endregion

        #region Events
        private void btnAnnulla_Click(object sender, EventArgs e) { Close(); }

        private void btnAggiungiModifica_Click(object sender, EventArgs e)
        {
            bool corretto = true;
            for (int i = 0; i < controls.Count && corretto; i++)
            {
                corretto = controllo(controls[i]);
                if (!corretto)
                    ErProv.setError(error, controls[i], "You must fill in all the required fields!");
            }
            if (btnAggiungiModifica.Text == "AGGIUNGI")
            {
                if (corretto)
                {
                    if (veicolo == "AUTO")
                    {
                        formMain.listaVeicoli.Add(new Auto(txtMarca.Text, txtModello.Text, txtColore.Text,
                                                           Convert.ToInt32(nmuCilindrata.Value),
                                                           Convert.ToDouble(nmuPotenza.Value),
                                                           dtpImmatricolazione.Value, chkUsato.Checked,
                                                           chkKmZero.Checked, Convert.ToInt32(nmuKmPercorsi.Value),
                                                           Convert.ToInt32(nmuPrezzo.Value),
                                                           Convert.ToInt32(nmuAirbag.Value)));
                    }
                    else
                    {
                        formMain.listaVeicoli.Add(new Moto(txtMarca.Text, txtModello.Text, txtColore.Text,
                                                           Convert.ToInt32(nmuCilindrata.Value),
                                                           Convert.ToDouble(nmuPotenza.Value),
                                                           dtpImmatricolazione.Value, chkUsato.Checked,
                                                           chkKmZero.Checked, Convert.ToInt32(nmuKmPercorsi.Value),
                                                           Convert.ToInt32(nmuPrezzo.Value),
                                                           txtMarcaSella.Text));
                    }
                    Close();
                }
            
            }
            else
            {
                if(corretto)
                {
                    formMain.listaVeicoli[selectedIndex].Marca = txtMarca.Text;
                    formMain.listaVeicoli[selectedIndex].Modello = txtModello.Text;
                    formMain.listaVeicoli[selectedIndex].Colore = txtColore.Text;
                    formMain.listaVeicoli[selectedIndex].Cilindrata = Convert.ToInt32(nmuCilindrata.Value);
                    formMain.listaVeicoli[selectedIndex].PotenzaKw = Convert.ToDouble(nmuPotenza.Value);
                    formMain.listaVeicoli[selectedIndex].Immatricolazione = dtpImmatricolazione.Value;
                    formMain.listaVeicoli[selectedIndex].IsUsato = chkUsato.Checked;
                    formMain.listaVeicoli[selectedIndex].IsKmZero = chkKmZero.Checked;
                    formMain.listaVeicoli[selectedIndex].KmPercorsi = Convert.ToInt32(nmuKmPercorsi.Value);
                    formMain.listaVeicoli[selectedIndex].Prezzo = Convert.ToInt32(nmuPrezzo.Value);
                    if (formMain.listaVeicoli[selectedIndex] is Moto)
                        (formMain.listaVeicoli[selectedIndex] as Moto).MarcaSella = txtMarcaSella.Text;
                    else
                        (formMain.listaVeicoli[selectedIndex] as Auto).NumAirbag = Convert.ToInt32(nmuAirbag.Value);
                    Close();
                }               
            }
        }

        private void cmbTipoVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            veicolo = cmbTipoVeicolo.Text;
            if (veicolo == "AUTO") setControlloAggiuntivo(true, false, nmuAirbag);
            else setControlloAggiuntivo(false, true, txtMarcaSella);
            changeBarValue();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            ErProv.resetError(error, sender as Control);
            changeBarValue();
        }
        #endregion

        #region Methods
        private void setControlloAggiuntivo(bool auto, bool moto, Control control)
        {
            nmuAirbag.Visible = lblNAirbag.Visible = auto;
            txtMarcaSella.Visible = lblMarcaSella.Visible = moto;
            controls.RemoveAt(controls.Count - 1);
            controls.Add(control);
        }

        private void changeBarValue()
        {
            int valoreBarra = 0;
            for (int i = 0; i < controls.Count; i++)
                if (controllo(controls[i])) valoreBarra++;

            progressBar.Value = valoreBarra;
        }

        private bool controllo(Control control) { return !(control.Text == string.Empty); }
        #endregion
    }
}
