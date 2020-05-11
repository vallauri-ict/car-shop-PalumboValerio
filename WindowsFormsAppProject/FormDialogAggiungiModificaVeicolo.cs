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
#endregion

namespace WindowsFormsAppProject
{
    public partial class FormDialogAggiungiModificaVeicolo : Form
    {
        #region Declaration
        List<Control> controls;
        string vehicle;
        FormMain formMain;
        private int selectedIndex;
        private ErrorProviderUtilities erProv = new ErrorProviderUtilities();
        #endregion

        #region Form
        public FormDialogAggiungiModificaVeicolo(FormMain formMain)
        {
            InitializeComponent();
            Control[] aus = { txtMarca, txtModello, txtColore, nmuCilindrata, nmuPotenza, nmuKmPercorsi, nmuPrezzo, nmuAirbag };
            controls = new List<Control>(aus);
            this.formMain = formMain;
            vehicle = "AUTO";

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
            txtMarca.Text = formMain.VehicleList[selectedIndex].Brand;
            txtModello.Text = formMain.VehicleList[selectedIndex].Model;
            txtColore.Text = formMain.VehicleList[selectedIndex].Color;
            nmuCilindrata.Value = formMain.VehicleList[selectedIndex].Displacement;
            nmuPotenza.Value = Convert.ToDecimal(formMain.VehicleList[selectedIndex].PowerKw);
            dtpImmatricolazione.Value = formMain.VehicleList[selectedIndex].Matriculation;
            chkUsato.Checked = formMain.VehicleList[selectedIndex].IsUsed;
            chkKmZero.Checked = formMain.VehicleList[selectedIndex].IsKm0;
            nmuKmPercorsi.Value = formMain.VehicleList[selectedIndex].KmDone;
            nmuPrezzo.Value = Convert.ToDecimal(formMain.VehicleList[selectedIndex].Price);
            if (formMain.VehicleList[selectedIndex] is Motorbikes)
            {
                cmbTipoVeicolo.SelectedIndex = 1;
                txtMarcaSella.Text = (formMain.VehicleList[selectedIndex] as Motorbikes).SaddleBrand;
            }
            else
                nmuAirbag.Value= (formMain.VehicleList[selectedIndex] as Cars).NumAirbag;
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
                    erProv.setError(error, controls[i], "Devi completare tutti i campi richiesti!");
            }
            if (btnAggiungiModifica.Text == "AGGIUNGI")
            {
                if (corretto)
                {
                    if (vehicle == "AUTO")
                    {
                        formMain.VehicleList.Add(new Cars(txtMarca.Text, txtModello.Text, txtColore.Text,
                                                           Convert.ToInt32(nmuCilindrata.Value),
                                                           Convert.ToDouble(nmuPotenza.Value),
                                                           dtpImmatricolazione.Value, chkUsato.Checked,
                                                           chkKmZero.Checked, Convert.ToInt32(nmuKmPercorsi.Value),
                                                           Convert.ToInt32(nmuPrezzo.Value),
                                                           Convert.ToInt32(nmuAirbag.Value)));
                    }
                    else
                    {
                        formMain.VehicleList.Add(new Motorbikes(txtMarca.Text, txtModello.Text, txtColore.Text,
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
                if(corretto && MessageBox.Show("Operazione non reversibile, vuoi procedere?", "Sei sicuro di voler modificare l'elemento selezionato?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    formMain.VehicleList[selectedIndex].Brand = txtMarca.Text;
                    formMain.VehicleList[selectedIndex].Model = txtModello.Text;
                    formMain.VehicleList[selectedIndex].Color = txtColore.Text;
                    formMain.VehicleList[selectedIndex].Displacement = Convert.ToInt32(nmuCilindrata.Value);
                    formMain.VehicleList[selectedIndex].PowerKw = Convert.ToDouble(nmuPotenza.Value);
                    formMain.VehicleList[selectedIndex].Matriculation = dtpImmatricolazione.Value;
                    formMain.VehicleList[selectedIndex].IsUsed = chkUsato.Checked;
                    formMain.VehicleList[selectedIndex].IsKm0 = chkKmZero.Checked;
                    formMain.VehicleList[selectedIndex].KmDone = Convert.ToInt32(nmuKmPercorsi.Value);
                    formMain.VehicleList[selectedIndex].Price = Convert.ToInt32(nmuPrezzo.Value);
                    if (formMain.VehicleList[selectedIndex] is Motorbikes)
                        (formMain.VehicleList[selectedIndex] as Motorbikes).SaddleBrand = txtMarcaSella.Text;
                    else
                        (formMain.VehicleList[selectedIndex] as Cars).NumAirbag = Convert.ToInt32(nmuAirbag.Value);
                    Close();
                }               
            }
        }

        private void cmbTipoVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehicle = cmbTipoVeicolo.Text;
            if (vehicle == "AUTO") setControlloAggiuntivo(true, false, nmuAirbag);
            else setControlloAggiuntivo(false, true, txtMarcaSella);
            changeBarValue();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            erProv.resetError(error, sender as Control);
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
