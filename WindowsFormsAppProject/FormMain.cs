﻿#region Using
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
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
#endregion

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        #region Initializations
        private ListUtilities listUtilities = new ListUtilities();
        private DBUtilities dbUtilities = new DBUtilities();
        private OpenXMLWordUtilities wordUtilities = new OpenXMLWordUtilities();
        private OpenXMLExcelUtilities excelUtilities = new OpenXMLExcelUtilities();
        private GeneralUtilities generalUtilities = new GeneralUtilities();

        public static string dbFilePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\CarShop.accdb";
        public static string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFilePath}";
        public SerializableBindingList<Vehicles> VehicleList; // The BindingList hears the changes during the code
        public FormMain()
        {
            InitializeComponent();
            VehicleList = new SerializableBindingList<Vehicles>();
            listBoxVehicles.DataSource = VehicleList;
            Start();
        }
        #endregion

        #region Events
        private void tsmNuovo_Click(object sender, EventArgs e)
        {
            FormDialogAddModifyVehicle dialogAddMod = new FormDialogAddModifyVehicle(this);
            dialogAddMod.ShowDialog();
        }

        private void tsbSalva_Click(object sender, EventArgs e)
        {
            dbUtilities.CreateBackup(dbFilePath);
            listUtilities.UpdateDb(VehicleList, connStr);
        }

        private void tsbCancella_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sei sicuro di voler eliminare l'elemento selezionato?", "CANCELLA VEICOLO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                VehicleList.RemoveAt(listBoxVehicles.SelectedIndex);
        }

        private void tsbModifica_Click(object sender, EventArgs e)
        {
            FormDialogAddModifyVehicle dialogAddMod = new FormDialogAddModifyVehicle(this, listBoxVehicles.SelectedIndex);
            if (dialogAddMod.ShowDialog() == DialogResult.OK)
            {
                dbUtilities.CreateBackup(dbFilePath);
                listUtilities.UpdateDb(VehicleList, connStr);
                Start();
            }
        }

        private void tsbStampa_Click(object sender, EventArgs e)
        {
            if (VehicleList.Count > 0)
            {                
                string homepagePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\www\\index.html";
                string skeletonPath = $"{ Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\www\\index-skeleton.html";
                listUtilities.CreateHtml(VehicleList, homepagePath, skeletonPath);
                Process.Start(homepagePath);
            }
            else
                MessageBox.Show("Inserisci almeno un veicolo prima di visualizzare!");
        }

        private void tsbWord_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filepath = generalUtilities.OutputFileName(fbd.SelectedPath, "docx");

                    using (WordprocessingDocument doc = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = doc.AddMainDocumentPart();

                        mainPart.Document = new Document();
                        Body body = mainPart.Document.AppendChild(new Body());

                        wordUtilities.AddStyle(mainPart, true, true, true, false, "MyHeading1", "Title", "Verdana", 16, "FF0000");
                        wordUtilities.AddStyle(mainPart, true, false, false, false, "MyHeading2", "Subtitle", "Verdana", 14, "FF0000");
                        wordUtilities.AddStyle(mainPart, false, false, false, false, "MyStartParagraph", "First", "Calibri", 15, "000000");
                        wordUtilities.AddStyle(mainPart, false, false, false, false, "MyParagraph2", "Second", "Calibri", 12, "000000");

                        AddParagraph(body, "MyHeading1", "AUTOPALU - VEICOLI NUOVI E USATI", JustificationValues.Center);
                        AddParagraph(body, "MyHeading2", "Le migliori occasioni al miglior prezzo!", JustificationValues.Center);
                        AddParagraph(body, "MyStartParagraph", "LISTA DEI VEICOLI DISPONIBILI:");

                        wordUtilities.CreateBulletNumberingPart(mainPart, "•");
                        for (int i = 0; i < VehicleList.Count; i++)
                        {
                            AddParagraph(body, "MyParagraph2", $"{VehicleList[i].Brand} {VehicleList[i].Model}");
                            string used = VehicleList[i].IsUsed ? "Si" : "No";
                            string km0 = VehicleList[i].IsKm0 ? "Si" : "No";
                            string[] elements = { $"Colore: {VehicleList[i].Color}",
                            $"Cilindrata: {VehicleList[i].Displacement}", $"Potenza: {VehicleList[i].Color} Kw",
                            $"Immatricolazione: {VehicleList[i].Matriculation.ToShortDateString()}",
                            $"Usato: {used}", $"Km zero: {km0}", $"Km Percorsi: {VehicleList[i].KmDone}",
                            $"Prezzo: {VehicleList[i].Price} €"};
                            List<Paragraph> bulletList = new List<Paragraph>();
                            wordUtilities.CreateBulletOrNumberedList(100, 200, bulletList, elements);
                            foreach (Paragraph paragraph in bulletList)
                                body.Append(paragraph);
                        }
                        ProcedureCompleted("Il documento è pronto!", filepath);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Problemi con il documento. Se è aperto da un altro programma, chiudilo e riprova...");
                }
            }
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filepath = generalUtilities.OutputFileName(fbd.SelectedPath, "xlsx");

                    List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                    for (int i = 0; i < VehicleList.Count; i++)
                    {
                        string used = VehicleList[i].IsUsed ? "Si" : "No";
                        string km0 = VehicleList[i].IsKm0 ? "Si" : "No";
                        Dictionary<string, string> excelContent = new Dictionary<string, string>();

                        excelContent.Add("Marca", VehicleList[i].Brand);
                        excelContent.Add("Modello", VehicleList[i].Model);
                        excelContent.Add("Colore", VehicleList[i].Color);
                        excelContent.Add("Cilindrata", VehicleList[i].Displacement.ToString());
                        excelContent.Add("Potenza", VehicleList[i].PowerKw.ToString() + " kw");
                        excelContent.Add("Immatricolazione", VehicleList[i].Matriculation.ToShortDateString());
                        excelContent.Add("Usato", used);
                        excelContent.Add("Km Zero", km0);
                        excelContent.Add("Km Percorsi", VehicleList[i].KmDone.ToString());
                        excelContent.Add("Prezzo", VehicleList[i].Price.ToString() + " €");
                        if ((VehicleList[i] is Cars)) excelContent.Add("Numero Airbag/Marca sella", (VehicleList[i] as Cars).NumAirbag.ToString());
                        else excelContent.Add("Numero Airbag/Marca sella", (VehicleList[i] as Motorbikes).SaddleBrand);
                        list.Add(excelContent);
                    }
                    using (SpreadsheetDocument package = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook))
                    {

                        excelUtilities.CreatePartsForExcel(package, list);

                        ProcedureCompleted("Il documento è pronto!", filepath);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Problemi con il documento. Se è aperto da un altro programma, chiudilo e riprova...");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Open the db
        /// </summary>
        private void Start()
        {
            VehicleList.Clear();
            listUtilities.OpenDBInList(VehicleList, connStr);
        }

        /// <summary>
        /// Add a Paragraph easily
        /// </summary>
        /// <param name="body"> Body of word document </param>
        private void AddParagraph(Body body, string idStyle, string text, JustificationValues justification = JustificationValues.Left)
        {
            Paragraph headingPar = wordUtilities.CreateParagraphWithStyle(idStyle, justification);
            wordUtilities.AddTextToParagraph(headingPar, text);
            body.AppendChild(headingPar);
        }

        /// <summary>
        /// Give at the user the confirm that the file creation is ended and start the file
        /// </summary>
        /// <param name="msg"> Message </param>
        /// <param name="filepath"> Path of file that must be open </param>
        private void ProcedureCompleted(string msg, string filepath)
        {
            MessageBox.Show(msg);
            Process.Start(filepath);
        }
        #endregion
    }
}
