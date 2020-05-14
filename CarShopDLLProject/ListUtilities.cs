#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Windows.Forms;
#endregion

namespace CarShopDLLProject
{
    #region SerializableBindingList
    [Serializable]
    public class SerializableBindingList<T> : BindingList<T> { }
    #endregion

    #region Utilities
    public class ListUtilities
    {
        public ListUtilities() { }
        public DBUtilities dbUtilities = new DBUtilities();
      
        /// <summary>
        /// Fill the list with db datas
        /// </summary>
        /// <param name="list"> List to fill </param>
        /// <param name="connStr"> String of connection </param>
        public void OpenDBInList(SerializableBindingList<Vehicles> list, string connStr)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    InsertItemInList(list, con, "Auto");
                    InsertItemInList(list, con, "Moto");
                }
            }
        }

        /// <summary>
        /// Take the item from the database in a list
        /// </summary>
        /// <param name="list"> Empty vehicles list </param>
        /// <param name="con"> Connection to database </param>
        private void InsertItemInList(SerializableBindingList<Vehicles> list, OleDbConnection con, string tableName)
        {
            OleDbCommand command = new OleDbCommand($"SELECT * FROM {tableName}", con);

            OleDbDataReader rdr = command.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    bool used = rdr.GetString(7) == "Si" ? true : false;
                    bool km0 = rdr.GetString(8) == "Si" ? true : false;
                    if (tableName == "Auto")
                    {
                        list.Add(new Cars(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                            rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetDateTime(6), used,
                            km0, rdr.GetInt32(9), Convert.ToDouble(rdr.GetDecimal(10)), rdr.GetString(12),
                            rdr.GetInt32(11)));
                    }
                    else
                    {
                        list.Add(new Motorbikes(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                            rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetDateTime(6), used,
                            km0, rdr.GetInt32(9), Convert.ToDouble(rdr.GetDecimal(10)), rdr.GetString(12),
                            rdr.GetString(11)));
                    }                        
                }
            }
            else MessageBox.Show("Non è stato trovato alcun dato", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            rdr.Close();
        }

        /// <summary>
        /// Update the db from json
        /// </summary>
        /// <param name="list"> List of vehicle </param>
        /// <param name="connStr"> String of connection </param>
        public void UpdateDb(SerializableBindingList<Vehicles> list, string connStr)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    dbUtilities.DropTable("Auto");
                    dbUtilities.DropTable("Moto");
                    dbUtilities.CreateTable("Auto");
                    dbUtilities.CreateTable("Moto");
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is Cars)
                        {
                            dbUtilities.AddNewItem("Auto", list[i].Brand,
                                    list[i].Model, list[i].Color, list[i].Displacement,
                                    list[i].PowerKw, list[i].Matriculation,
                                    list[i].IsUsed, list[i].IsKm0, list[i].KmDone,
                                    list[i].Price, (list[i] as Cars).NumAirbag, "", list[i].Img);
                        }
                        else
                        {
                            dbUtilities.AddNewItem("Moto", list[i].Brand,
                                    list[i].Model, list[i].Color, list[i].Displacement,
                                    list[i].PowerKw, list[i].Matriculation,
                                    list[i].IsUsed, list[i].IsKm0, list[i].KmDone,
                                    list[i].Price, 0, (list[i] as Motorbikes).SaddleBrand, list[i].Img);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create the html
        /// </summary>
        /// <param name="list"> List with datas </param>
        /// <param name="pathName"> index.html path </param>
        /// <param name="skeletonPathName"> Auxiliary index.html </param>
        public void CreateHtml(SerializableBindingList<Vehicles> list, string pathName, string skeletonPathName = @".\www\index-skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName);
            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "AUTOPALU - VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "Le migliori occasioni al miglior prezzo!");
            

            string mainContent = "<h3> LISTA DEI VEICOLI DISPONIBILI </h3>";
            for (int i = 0; i < list.Count; i++)
                CreateBody(ref mainContent, list, i);

            html = html.Replace("{{main-content}}", mainContent);
            File.WriteAllText(pathName, html);
        }
        
        /// <summary>
        /// Create body for the html file
        /// </summary>
        /// <param name="mainContent"> Content to add </param>
        /// <param name="list"> List with datas </param>
        /// <param name="i"> List data position </param>
        private void CreateBody(ref string mainContent, SerializableBindingList<Vehicles> list, int i)
        {
            string used = string.Empty;
            string km0 = string.Empty;

            if (list[i].IsKm0) km0 = "Chilometro zero,";

            if (list[i].IsUsed) used = "Usato";
            else used = "Nuovo";


            mainContent += "<div class = \"veicolo\">";
            mainContent += $"<img src = \"../img/{list[i].Img}\">";
            mainContent += $"<div class = \"titolo\">{list[i].Brand} {list[i].Model}";
            mainContent += $"<div class = \"didascalia\"> Colore: {list[i].Color}<br> Cilindrata: {list[i].Displacement}<br> Immatricolazione: {list[i].Matriculation.ToString("dd/MM/yyyy")}<br> {km0} {used} <br> Chilometri percorsi: {list[i].KmDone}<br> Potenza: {list[i].PowerKw} <br> Prezzo: {list[i].Price} € </div>";
            mainContent += "</div>";
            mainContent += "</div>";
        }
    }
    #endregion
}
