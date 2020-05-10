﻿namespace WindowsFormsAppProject
{
    partial class FormMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listBoxVeicoli = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuovo = new System.Windows.Forms.ToolStripButton();
            this.tsbApri = new System.Windows.Forms.ToolStripButton();
            this.tsbSalva = new System.Windows.Forms.ToolStripButton();
            this.tsbCancella = new System.Windows.Forms.ToolStripButton();
            this.tsbStampa = new System.Windows.Forms.ToolStripButton();
            this.tsbModifica = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxVeicoli
            // 
            this.listBoxVeicoli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxVeicoli.FormattingEnabled = true;
            this.listBoxVeicoli.ItemHeight = 16;
            this.listBoxVeicoli.Location = new System.Drawing.Point(0, 27);
            this.listBoxVeicoli.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVeicoli.Name = "listBoxVeicoli";
            this.listBoxVeicoli.Size = new System.Drawing.Size(779, 417);
            this.listBoxVeicoli.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuovo,
            this.tsbApri,
            this.tsbSalva,
            this.tsbCancella,
            this.tsbModifica,
            this.tsbStampa});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(779, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuovo
            // 
            this.tsbNuovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuovo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuovo.Image")));
            this.tsbNuovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuovo.Name = "tsbNuovo";
            this.tsbNuovo.Size = new System.Drawing.Size(29, 24);
            this.tsbNuovo.Text = "&Nuovo";
            this.tsbNuovo.Click += new System.EventHandler(this.tsmNuovo_Click);
            // 
            // tsbApri
            // 
            this.tsbApri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbApri.Image = ((System.Drawing.Image)(resources.GetObject("tsbApri.Image")));
            this.tsbApri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApri.Name = "tsbApri";
            this.tsbApri.Size = new System.Drawing.Size(29, 24);
            this.tsbApri.Text = "&Apri";
            this.tsbApri.Click += new System.EventHandler(this.tsbApri_Click);
            // 
            // tsbSalva
            // 
            this.tsbSalva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalva.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalva.Image")));
            this.tsbSalva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalva.Name = "tsbSalva";
            this.tsbSalva.Size = new System.Drawing.Size(29, 24);
            this.tsbSalva.Text = "&Salva";
            this.tsbSalva.Click += new System.EventHandler(this.tsbSalva_Click);
            // 
            // tsbCancella
            // 
            this.tsbCancella.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancella.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancella.Image")));
            this.tsbCancella.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancella.Name = "tsbCancella";
            this.tsbCancella.Size = new System.Drawing.Size(29, 24);
            this.tsbCancella.Text = "&Cancella";
            this.tsbCancella.Click += new System.EventHandler(this.tsbCancella_Click);
            // 
            // tsbStampa
            // 
            this.tsbStampa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStampa.Image = ((System.Drawing.Image)(resources.GetObject("tsbStampa.Image")));
            this.tsbStampa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStampa.Name = "tsbStampa";
            this.tsbStampa.Size = new System.Drawing.Size(29, 24);
            this.tsbStampa.Text = "S&tampa";
            this.tsbStampa.Click += new System.EventHandler(this.tsbStampa_Click);
            // 
            // tsbModifica
            // 
            this.tsbModifica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModifica.Image = ((System.Drawing.Image)(resources.GetObject("tsbModifica.Image")));
            this.tsbModifica.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModifica.Name = "tsbModifica";
            this.tsbModifica.Size = new System.Drawing.Size(29, 24);
            this.tsbModifica.Text = "&Modifica";
            this.tsbModifica.Click += new System.EventHandler(this.tsbModifica_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 444);
            this.Controls.Add(this.listBoxVeicoli);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "SALONE VEICOLI NUOVI E USATI";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVeicoli;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuovo;
        private System.Windows.Forms.ToolStripButton tsbApri;
        private System.Windows.Forms.ToolStripButton tsbSalva;
        private System.Windows.Forms.ToolStripButton tsbStampa;
        private System.Windows.Forms.ToolStripButton tsbCancella;
        private System.Windows.Forms.ToolStripButton tsbModifica;
    }
}

