namespace WindowsFormsAppProject
{
    partial class FormDialogAggiungiVeicolo
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
            this.cmbTipoVeicolo = new System.Windows.Forms.ComboBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nmuCilindrata = new System.Windows.Forms.NumericUpDown();
            this.nmuPotenza = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpImmatricolazione = new System.Windows.Forms.DateTimePicker();
            this.lblNAirbag = new System.Windows.Forms.Label();
            this.nmuAirbag = new System.Windows.Forms.NumericUpDown();
            this.txtMarcaSella = new System.Windows.Forms.TextBox();
            this.lblMarcaSella = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkUsato = new System.Windows.Forms.CheckBox();
            this.chkKmZero = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.nmuKmPercorsi = new System.Windows.Forms.NumericUpDown();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.nmuCilindrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuPotenza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuAirbag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuKmPercorsi)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoVeicolo
            // 
            this.cmbTipoVeicolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVeicolo.FormattingEnabled = true;
            this.cmbTipoVeicolo.Items.AddRange(new object[] {
            "AUTO",
            "MOTO"});
            this.cmbTipoVeicolo.Location = new System.Drawing.Point(109, 42);
            this.cmbTipoVeicolo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoVeicolo.Name = "cmbTipoVeicolo";
            this.cmbTipoVeicolo.Size = new System.Drawing.Size(160, 24);
            this.cmbTipoVeicolo.TabIndex = 0;
            this.cmbTipoVeicolo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVeicolo_SelectedIndexChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(169, 463);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(100, 28);
            this.btnAnnulla.TabIndex = 1;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(277, 463);
            this.btnAggiungi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(100, 28);
            this.btnAggiungi.TabIndex = 2;
            this.btnAggiungi.Text = "AGGIUNGI";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Marca:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(169, 98);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(132, 22);
            this.txtMarca.TabIndex = 4;
            this.txtMarca.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(169, 133);
            this.txtModello.Margin = new System.Windows.Forms.Padding(4);
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(132, 22);
            this.txtModello.TabIndex = 6;
            this.txtModello.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Modello:";
            // 
            // txtColore
            // 
            this.txtColore.Location = new System.Drawing.Point(169, 167);
            this.txtColore.Margin = new System.Windows.Forms.Padding(4);
            this.txtColore.Name = "txtColore";
            this.txtColore.Size = new System.Drawing.Size(132, 22);
            this.txtColore.TabIndex = 8;
            this.txtColore.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Colore:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cilindrata:";
            // 
            // nmuCilindrata
            // 
            this.nmuCilindrata.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmuCilindrata.Location = new System.Drawing.Point(169, 201);
            this.nmuCilindrata.Margin = new System.Windows.Forms.Padding(4);
            this.nmuCilindrata.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nmuCilindrata.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmuCilindrata.Name = "nmuCilindrata";
            this.nmuCilindrata.Size = new System.Drawing.Size(132, 22);
            this.nmuCilindrata.TabIndex = 10;
            this.nmuCilindrata.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmuCilindrata.ValueChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // nmuPotenza
            // 
            this.nmuPotenza.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmuPotenza.Location = new System.Drawing.Point(169, 235);
            this.nmuPotenza.Margin = new System.Windows.Forms.Padding(4);
            this.nmuPotenza.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmuPotenza.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmuPotenza.Name = "nmuPotenza";
            this.nmuPotenza.Size = new System.Drawing.Size(132, 22);
            this.nmuPotenza.TabIndex = 12;
            this.nmuPotenza.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmuPotenza.ValueChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Potenza:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 267);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Immatricolazione:";
            // 
            // dtpImmatricolazione
            // 
            this.dtpImmatricolazione.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpImmatricolazione.Location = new System.Drawing.Point(169, 270);
            this.dtpImmatricolazione.Margin = new System.Windows.Forms.Padding(4);
            this.dtpImmatricolazione.MaxDate = new System.DateTime(2019, 12, 13, 0, 0, 0, 0);
            this.dtpImmatricolazione.Name = "dtpImmatricolazione";
            this.dtpImmatricolazione.Size = new System.Drawing.Size(132, 22);
            this.dtpImmatricolazione.TabIndex = 14;
            this.dtpImmatricolazione.Value = new System.DateTime(2019, 12, 4, 0, 0, 0, 0);
            // 
            // lblNAirbag
            // 
            this.lblNAirbag.AutoSize = true;
            this.lblNAirbag.Location = new System.Drawing.Point(37, 370);
            this.lblNAirbag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNAirbag.Name = "lblNAirbag";
            this.lblNAirbag.Size = new System.Drawing.Size(107, 17);
            this.lblNAirbag.TabIndex = 18;
            this.lblNAirbag.Text = "Numero Airbag:";
            // 
            // nmuAirbag
            // 
            this.nmuAirbag.Location = new System.Drawing.Point(169, 370);
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
            this.nmuAirbag.TabIndex = 19;
            this.nmuAirbag.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmuAirbag.ValueChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtMarcaSella
            // 
            this.txtMarcaSella.Location = new System.Drawing.Point(169, 404);
            this.txtMarcaSella.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarcaSella.Name = "txtMarcaSella";
            this.txtMarcaSella.Size = new System.Drawing.Size(132, 22);
            this.txtMarcaSella.TabIndex = 21;
            this.txtMarcaSella.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblMarcaSella
            // 
            this.lblMarcaSella.AutoSize = true;
            this.lblMarcaSella.Location = new System.Drawing.Point(37, 402);
            this.lblMarcaSella.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarcaSella.Name = "lblMarcaSella";
            this.lblMarcaSella.Size = new System.Drawing.Size(84, 17);
            this.lblMarcaSella.TabIndex = 20;
            this.lblMarcaSella.Text = "Marca sella:";
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // chkUsato
            // 
            this.chkUsato.AutoSize = true;
            this.chkUsato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUsato.Location = new System.Drawing.Point(39, 300);
            this.chkUsato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUsato.Name = "chkUsato";
            this.chkUsato.Size = new System.Drawing.Size(67, 21);
            this.chkUsato.TabIndex = 24;
            this.chkUsato.Text = "Usato";
            this.chkUsato.UseVisualStyleBackColor = true;
            // 
            // chkKmZero
            // 
            this.chkKmZero.AutoSize = true;
            this.chkKmZero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkKmZero.Location = new System.Drawing.Point(172, 303);
            this.chkKmZero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkKmZero.Name = "chkKmZero";
            this.chkKmZero.Size = new System.Drawing.Size(129, 21);
            this.chkKmZero.TabIndex = 25;
            this.chkKmZero.Text = "Chilometro zero";
            this.chkKmZero.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(39, 427);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Maximum = 7;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(253, 23);
            this.progressBar.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 337);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Chilometri percorsi:";
            // 
            // nmuKmPercorsi
            // 
            this.nmuKmPercorsi.Location = new System.Drawing.Point(169, 336);
            this.nmuKmPercorsi.Margin = new System.Windows.Forms.Padding(4);
            this.nmuKmPercorsi.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmuKmPercorsi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmuKmPercorsi.Name = "nmuKmPercorsi";
            this.nmuKmPercorsi.Size = new System.Drawing.Size(132, 22);
            this.nmuKmPercorsi.TabIndex = 28;
            this.nmuKmPercorsi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormDialogAggiungiVeicolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(379, 506);
            this.Controls.Add(this.nmuKmPercorsi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.chkKmZero);
            this.Controls.Add(this.chkUsato);
            this.Controls.Add(this.nmuAirbag);
            this.Controls.Add(this.lblNAirbag);
            this.Controls.Add(this.txtMarcaSella);
            this.Controls.Add(this.lblMarcaSella);
            this.Controls.Add(this.dtpImmatricolazione);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nmuPotenza);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nmuCilindrata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtColore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.cmbTipoVeicolo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDialogAggiungiVeicolo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AGGIUNGI VEICOLO";
            ((System.ComponentModel.ISupportInitialize)(this.nmuCilindrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuPotenza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuAirbag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuKmPercorsi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoVeicolo;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmuCilindrata;
        private System.Windows.Forms.NumericUpDown nmuPotenza;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpImmatricolazione;
        private System.Windows.Forms.Label lblNAirbag;
        private System.Windows.Forms.NumericUpDown nmuAirbag;
        private System.Windows.Forms.TextBox txtMarcaSella;
        private System.Windows.Forms.Label lblMarcaSella;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.CheckBox chkKmZero;
        private System.Windows.Forms.CheckBox chkUsato;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.NumericUpDown nmuKmPercorsi;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}