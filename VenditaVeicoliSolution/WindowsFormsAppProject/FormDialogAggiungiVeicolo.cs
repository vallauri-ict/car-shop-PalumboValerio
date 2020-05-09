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
    public partial class FormDialogAggiungiVeicolo : Form
    {
        #region Dichiarazioni
        List<Control> controls;
        string veicolo;
        FormMain formMain;
        #endregion

        #region Form
        public FormDialogAggiungiVeicolo(FormMain formMain)
        {
            InitializeComponent();
            Control[] aus = { txtMarca, txtModello, txtColore, nmuCilindrata, nmuPotenza, nmuKmPercorsi, nmuPrezzo, nmuAirbag };
            controls = new List<Control>(aus);
            this.formMain = formMain;
            veicolo = "AUTO";

            cmbTipoVeicolo.SelectedIndex = 0;
            lblMarcaSella.Location = lblNAirbag.Location;
            txtMarcaSella.Location = nmuAirbag.Location;
            dtpImmatricolazione.MaxDate = DateTime.Today;
            dtpImmatricolazione.Value = DateTime.Today;
            txtMarcaSella.Visible = lblMarcaSella.Visible = false;
        }
        #endregion

        #region Eventi
        private void btnAnnulla_Click(object sender, EventArgs e) { Close(); }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            bool corretto = true;
            for (int i = 0; i < controls.Count && corretto; i++)
            {
                corretto = controllo(controls[i]);
                if (!corretto)
                    ErProv.setError(error, controls[i], "You must fill in all the required fields!");
            }
            
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

        #region Metodi
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
