namespace WindowsFormsAppProject
{
    partial class FormDialogAddModifyVehicle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogAddModifyVehicle));
            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddModify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nmuDisplacement = new System.Windows.Forms.NumericUpDown();
            this.nmuPower = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpMatriculation = new System.Windows.Forms.DateTimePicker();
            this.lblNAirbag = new System.Windows.Forms.Label();
            this.nmuAirbag = new System.Windows.Forms.NumericUpDown();
            this.txtSaddleBrand = new System.Windows.Forms.TextBox();
            this.lblSaddleBrand = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkIsUsed = new System.Windows.Forms.CheckBox();
            this.chkIsKmZero = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.nmuKmDone = new System.Windows.Forms.NumericUpDown();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.label8 = new System.Windows.Forms.Label();
            this.nmuPrice = new System.Windows.Forms.NumericUpDown();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tlbUpload = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nmuDisplacement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuAirbag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuKmDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuPrice)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Items.AddRange(new object[] {
            "AUTO",
            "MOTO"});
            this.cmbVehicleType.Location = new System.Drawing.Point(109, 42);
            this.cmbVehicleType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(160, 24);
            this.cmbVehicleType.TabIndex = 0;
            this.cmbVehicleType.SelectedIndexChanged += new System.EventHandler(this.cmbVehicleType_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(169, 484);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "ANNULLA";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddModify
            // 
            this.btnAddModify.Location = new System.Drawing.Point(277, 484);
            this.btnAddModify.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddModify.Name = "btnAddModify";
            this.btnAddModify.Size = new System.Drawing.Size(100, 28);
            this.btnAddModify.TabIndex = 11;
            this.btnAddModify.Text = "AGGIUNGI";
            this.btnAddModify.UseVisualStyleBackColor = true;
            this.btnAddModify.Click += new System.EventHandler(this.btnAddModify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca:";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(169, 98);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(4);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(132, 22);
            this.txtBrand.TabIndex = 1;
            this.txtBrand.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(169, 133);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(132, 22);
            this.txtModel.TabIndex = 2;
            this.txtModel.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Modello:";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(169, 167);
            this.txtColor.Margin = new System.Windows.Forms.Padding(4);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(132, 22);
            this.txtColor.TabIndex = 3;
            this.txtColor.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Colore:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cilindrata:";
            // 
            // nmuDisplacement
            // 
            this.nmuDisplacement.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmuDisplacement.Location = new System.Drawing.Point(169, 201);
            this.nmuDisplacement.Margin = new System.Windows.Forms.Padding(4);
            this.nmuDisplacement.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nmuDisplacement.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmuDisplacement.Name = "nmuDisplacement";
            this.nmuDisplacement.Size = new System.Drawing.Size(132, 22);
            this.nmuDisplacement.TabIndex = 4;
            this.nmuDisplacement.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmuDisplacement.ValueChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // nmuPower
            // 
            this.nmuPower.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmuPower.Location = new System.Drawing.Point(169, 235);
            this.nmuPower.Margin = new System.Windows.Forms.Padding(4);
            this.nmuPower.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmuPower.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmuPower.Name = "nmuPower";
            this.nmuPower.Size = new System.Drawing.Size(132, 22);
            this.nmuPower.TabIndex = 5;
            this.nmuPower.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmuPower.ValueChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Potenza:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 267);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Immatricolazione:";
            // 
            // dtpMatriculation
            // 
            this.dtpMatriculation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMatriculation.Location = new System.Drawing.Point(169, 270);
            this.dtpMatriculation.Margin = new System.Windows.Forms.Padding(4);
            this.dtpMatriculation.MaxDate = new System.DateTime(2019, 12, 13, 0, 0, 0, 0);
            this.dtpMatriculation.Name = "dtpMatriculation";
            this.dtpMatriculation.Size = new System.Drawing.Size(132, 22);
            this.dtpMatriculation.TabIndex = 6;
            this.dtpMatriculation.Value = new System.DateTime(2019, 12, 4, 0, 0, 0, 0);
            // 
            // lblNAirbag
            // 
            this.lblNAirbag.AutoSize = true;
            this.lblNAirbag.Location = new System.Drawing.Point(36, 401);
            this.lblNAirbag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNAirbag.Name = "lblNAirbag";
            this.lblNAirbag.Size = new System.Drawing.Size(107, 17);
            this.lblNAirbag.TabIndex = 0;
            this.lblNAirbag.Text = "Numero Airbag:";
            // 
            // nmuAirbag
            // 
            this.nmuAirbag.Location = new System.Drawing.Point(169, 399);
            this.nmuAirbag.Margin = new System.Windows.Forms.Padding(4);
            this.nmuAirbag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmuAirbag.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmuAirbag.Name = "nmuAirbag";
            this.nmuAirbag.Size = new System.Drawing.Size(132, 22);
            this.nmuAirbag.TabIndex = 9;
            this.nmuAirbag.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmuAirbag.ValueChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtSaddleBrand
            // 
            this.txtSaddleBrand.Location = new System.Drawing.Point(169, 427);
            this.txtSaddleBrand.Margin = new System.Windows.Forms.Padding(4);
            this.txtSaddleBrand.Name = "txtSaddleBrand";
            this.txtSaddleBrand.Size = new System.Drawing.Size(132, 22);
            this.txtSaddleBrand.TabIndex = 9;
            this.txtSaddleBrand.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblSaddleBrand
            // 
            this.lblSaddleBrand.AutoSize = true;
            this.lblSaddleBrand.Location = new System.Drawing.Point(37, 427);
            this.lblSaddleBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaddleBrand.Name = "lblSaddleBrand";
            this.lblSaddleBrand.Size = new System.Drawing.Size(84, 17);
            this.lblSaddleBrand.TabIndex = 0;
            this.lblSaddleBrand.Text = "Marca sella:";
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // chkIsUsed
            // 
            this.chkIsUsed.AutoSize = true;
            this.chkIsUsed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsUsed.Location = new System.Drawing.Point(39, 300);
            this.chkIsUsed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsUsed.Name = "chkIsUsed";
            this.chkIsUsed.Size = new System.Drawing.Size(67, 21);
            this.chkIsUsed.TabIndex = 0;
            this.chkIsUsed.Text = "Usato";
            this.chkIsUsed.UseVisualStyleBackColor = true;
            // 
            // chkIsKmZero
            // 
            this.chkIsKmZero.AutoSize = true;
            this.chkIsKmZero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsKmZero.Location = new System.Drawing.Point(172, 303);
            this.chkIsKmZero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsKmZero.Name = "chkIsKmZero";
            this.chkIsKmZero.Size = new System.Drawing.Size(129, 21);
            this.chkIsKmZero.TabIndex = 0;
            this.chkIsKmZero.Text = "Chilometro zero";
            this.chkIsKmZero.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(39, 455);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Maximum = 8;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(253, 23);
            this.progressBar.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 337);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Chilometri percorsi:";
            // 
            // nmuKmDone
            // 
            this.nmuKmDone.Location = new System.Drawing.Point(169, 336);
            this.nmuKmDone.Margin = new System.Windows.Forms.Padding(4);
            this.nmuKmDone.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmuKmDone.Name = "nmuKmDone";
            this.nmuKmDone.Size = new System.Drawing.Size(132, 22);
            this.nmuKmDone.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 372);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Prezzo:";
            // 
            // nmuPrice
            // 
            this.nmuPrice.Location = new System.Drawing.Point(169, 369);
            this.nmuPrice.Margin = new System.Windows.Forms.Padding(4);
            this.nmuPrice.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nmuPrice.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nmuPrice.Name = "nmuPrice";
            this.nmuPrice.Size = new System.Drawing.Size(132, 22);
            this.nmuPrice.TabIndex = 8;
            this.nmuPrice.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbUpload});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(379, 27);
            this.toolStrip.TabIndex = 13;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tlbUpload
            // 
            this.tlbUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbUpload.Image = ((System.Drawing.Image)(resources.GetObject("tlbUpload.Image")));
            this.tlbUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbUpload.Name = "tlbUpload";
            this.tlbUpload.Size = new System.Drawing.Size(29, 24);
            this.tlbUpload.Text = "&Carica immagine";
            this.tlbUpload.Click += new System.EventHandler(this.tlbUpload_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // FormDialogAddModifyVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(379, 525);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.nmuPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nmuKmDone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.chkIsKmZero);
            this.Controls.Add(this.chkIsUsed);
            this.Controls.Add(this.nmuAirbag);
            this.Controls.Add(this.lblNAirbag);
            this.Controls.Add(this.txtSaddleBrand);
            this.Controls.Add(this.lblSaddleBrand);
            this.Controls.Add(this.dtpMatriculation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nmuPower);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nmuDisplacement);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddModify);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbVehicleType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDialogAddModifyVehicle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AGGIUNGI VEICOLO";
            ((System.ComponentModel.ISupportInitialize)(this.nmuDisplacement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuAirbag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuKmDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuPrice)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmuDisplacement;
        private System.Windows.Forms.NumericUpDown nmuPower;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpMatriculation;
        private System.Windows.Forms.Label lblNAirbag;
        private System.Windows.Forms.NumericUpDown nmuAirbag;
        private System.Windows.Forms.TextBox txtSaddleBrand;
        private System.Windows.Forms.Label lblSaddleBrand;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.CheckBox chkIsKmZero;
        private System.Windows.Forms.CheckBox chkIsUsed;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.NumericUpDown nmuKmDone;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.NumericUpDown nmuPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tlbUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}