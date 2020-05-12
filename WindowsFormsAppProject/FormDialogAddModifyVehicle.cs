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
    public partial class FormDialogAddModifyVehicle : Form
    {
        #region Declaration
        List<Control> controls;
        string vehicle;
        FormMain formMain;
        private int selectedIndex;
        private ErrorProviderUtilities erProv = new ErrorProviderUtilities();
        #endregion

        #region Form
        public FormDialogAddModifyVehicle(FormMain formMain)
        {
            InitializeComponent();
            Control[] aus = { txtBrand, txtModel, txtColor, nmuDisplacement, nmuPower, nmuKmDone, nmuPrice, nmuAirbag };
            controls = new List<Control>(aus);
            this.formMain = formMain;
            vehicle = "AUTO";

            Text = "AGGIUNGI VEICOLO";
            btnAddModify.Text = "AGGIUNGI";
            cmbVehicleType.Enabled = true;
            cmbVehicleType.SelectedIndex = 0;
            lblSaddleBrand.Location = lblNAirbag.Location;
            txtSaddleBrand.Location = nmuAirbag.Location;
            dtpMatriculation.MaxDate = DateTime.Today;
            dtpMatriculation.Value = DateTime.Today;
            txtSaddleBrand.Visible = lblSaddleBrand.Visible = false;
        }

        public FormDialogAddModifyVehicle(FormMain formMain, int selectedIndex) : this(formMain)
        {
            Text = "MODIFICA VEICOLO";
            cmbVehicleType.Enabled = false;
            txtBrand.Text = formMain.VehicleList[selectedIndex].Brand;
            txtModel.Text = formMain.VehicleList[selectedIndex].Model;
            txtColor.Text = formMain.VehicleList[selectedIndex].Color;
            nmuDisplacement.Value = formMain.VehicleList[selectedIndex].Displacement;
            nmuPower.Value = Convert.ToDecimal(formMain.VehicleList[selectedIndex].PowerKw);
            dtpMatriculation.Value = formMain.VehicleList[selectedIndex].Matriculation;
            chkIsUsed.Checked = formMain.VehicleList[selectedIndex].IsUsed;
            chkIsKmZero.Checked = formMain.VehicleList[selectedIndex].IsKm0;
            nmuKmDone.Value = formMain.VehicleList[selectedIndex].KmDone;
            nmuPrice.Value = Convert.ToDecimal(formMain.VehicleList[selectedIndex].Price);
            if (formMain.VehicleList[selectedIndex] is Motorbikes)
            {
                cmbVehicleType.SelectedIndex = 1;
                txtSaddleBrand.Text = (formMain.VehicleList[selectedIndex] as Motorbikes).SaddleBrand;
            }
            else
                nmuAirbag.Value= (formMain.VehicleList[selectedIndex] as Cars).NumAirbag;
            btnAddModify.Text = "MODIFICA";
            this.selectedIndex = selectedIndex;
        }
        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }

        private void btnAddModify_Click(object sender, EventArgs e)
        {
            bool corretto = true;
            for (int i = 0; i < controls.Count && corretto; i++)
            {
                corretto = controllo(controls[i]);
                if (!corretto)
                    erProv.setError(error, controls[i], "Devi completare tutti i campi richiesti!");
            }
            if (btnAddModify.Text == "AGGIUNGI")
            {
                if (corretto)
                {
                    if (vehicle == "AUTO")
                    {
                        formMain.VehicleList.Add(new Cars(txtBrand.Text, txtModel.Text, txtColor.Text,
                                                           Convert.ToInt32(nmuDisplacement.Value),
                                                           Convert.ToDouble(nmuPower.Value),
                                                           dtpMatriculation.Value, chkIsUsed.Checked,
                                                           chkIsKmZero.Checked, Convert.ToInt32(nmuKmDone.Value),
                                                           Convert.ToInt32(nmuPrice.Value),
                                                           Convert.ToInt32(nmuAirbag.Value)));
                    }
                    else
                    {
                        formMain.VehicleList.Add(new Motorbikes(txtBrand.Text, txtModel.Text, txtColor.Text,
                                                           Convert.ToInt32(nmuDisplacement.Value),
                                                           Convert.ToDouble(nmuPower.Value),
                                                           dtpMatriculation.Value, chkIsUsed.Checked,
                                                           chkIsKmZero.Checked, Convert.ToInt32(nmuKmDone.Value),
                                                           Convert.ToInt32(nmuPrice.Value),
                                                           txtSaddleBrand.Text));
                    }
                    Close();
                }
            
            }
            else
            {
                if(corretto && MessageBox.Show("Operazione non reversibile, vuoi procedere?", "Sei sicuro di voler modificare l'elemento selezionato?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    formMain.VehicleList[selectedIndex].Brand = txtBrand.Text;
                    formMain.VehicleList[selectedIndex].Model = txtModel.Text;
                    formMain.VehicleList[selectedIndex].Color = txtColor.Text;
                    formMain.VehicleList[selectedIndex].Displacement = Convert.ToInt32(nmuDisplacement.Value);
                    formMain.VehicleList[selectedIndex].PowerKw = Convert.ToDouble(nmuPower.Value);
                    formMain.VehicleList[selectedIndex].Matriculation = dtpMatriculation.Value;
                    formMain.VehicleList[selectedIndex].IsUsed = chkIsUsed.Checked;
                    formMain.VehicleList[selectedIndex].IsKm0 = chkIsKmZero.Checked;
                    formMain.VehicleList[selectedIndex].KmDone = Convert.ToInt32(nmuKmDone.Value);
                    formMain.VehicleList[selectedIndex].Price = Convert.ToInt32(nmuPrice.Value);
                    if (formMain.VehicleList[selectedIndex] is Motorbikes)
                        (formMain.VehicleList[selectedIndex] as Motorbikes).SaddleBrand = txtSaddleBrand.Text;
                    else
                        (formMain.VehicleList[selectedIndex] as Cars).NumAirbag = Convert.ToInt32(nmuAirbag.Value);
                    Close();
                }               
            }
        }

        private void cmbVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehicle = cmbVehicleType.Text;
            if (vehicle == "AUTO") setControlloAggiuntivo(true, false, nmuAirbag);
            else setControlloAggiuntivo(false, true, txtSaddleBrand);
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
            txtSaddleBrand.Visible = lblSaddleBrand.Visible = moto;
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
