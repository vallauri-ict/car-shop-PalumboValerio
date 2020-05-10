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
#endregion

namespace VenditaVeicoliDLLProject
{
    #region SerializableBindingList
    [Serializable]
    public class SerializableBindingList<T> : BindingList<T> { }
    #endregion

    #region Utilities
    public class FormUtilities
    {
        /// <summary>
        /// Serialize an object list into Json string
        /// </summary>
        /// <param name="objectlist"> List to convert into Json string </param>
        /// <param name="pathName"> Json file path </param>
        public static void SerializeToJson<T>(IEnumerable<T> objectlist, string pathName)
        {
            string json = JsonConvert.SerializeObject(objectlist, Formatting.Indented);
            File.WriteAllText(pathName, json);            
        }

        /// <summary>
        /// Update the json file from db
        /// </summary>
        /// <param name="connStr"> String of connection </param>
        public static void UpdateJson(string jsonFilePath, string connStr)
        {
            SerializableBindingList<Veicoli> list = new SerializableBindingList<Veicoli>();
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    InsertItemInList(list, con, "Auto");
                    InsertItemInList(list, con, "Moto");
                    SerializeToJson(list, jsonFilePath);
                }
            }
        }

        /// <summary>
        /// Take the item from the database in a list
        /// </summary>
        /// <param name="list"> Empty vehicles list </param>
        /// <param name="con"> Connection to database </param>
        private static void InsertItemInList(SerializableBindingList<Veicoli> list, OleDbConnection con, string tableName)
        {
            OleDbCommand command = new OleDbCommand($"SELECT * FROM {tableName}", con);

            OleDbDataReader rdr = command.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (tableName == "Auto")
                    {
                        list.Add(new Auto(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                            rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetDateTime(6), rdr.GetBoolean(7),
                            rdr.GetBoolean(8), rdr.GetInt32(9), rdr.GetInt32(10), rdr.GetInt32(11)));
                    }
                    else
                    {
                        list.Add(new Moto(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                            rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetDateTime(6), rdr.GetBoolean(7),
                            rdr.GetBoolean(8), rdr.GetInt32(9), rdr.GetInt32(10), rdr.GetString(11)));
                    }                        
                }
            }
            rdr.Close();
        }

        /// <summary>
        /// Parse a Json string into an object list
        /// </summary>
        /// <param name="pathName"> Json file path </param>
        /// <param name="objectlist"> List to fill with json string elements </param>
        public static void ParseJsonToObject(string pathName, SerializableBindingList<Veicoli> objectlist)
        {
            string json = File.ReadAllText(pathName);

            object[] veicoli = JsonConvert.DeserializeObject<object[]>(json);
            for (int i = 0; i < veicoli.Length; i++)
            {
                Moto moto = new Moto();
                Auto auto = new Auto();
                string veicolo = veicoli[i].ToString();
                if (veicolo.Contains("MarcaSella"))
                {
                    JsonConvert.PopulateObject(veicolo, moto);
                    objectlist.Add(moto);
                }
                else
                {
                    JsonConvert.PopulateObject(veicolo, auto);
                    objectlist.Add(auto);
                }
            }
        }

        /// <summary>
        /// Create the html
        /// </summary>
        /// <param name="objectList"> List with datas </param>
        /// <param name="pathName"> index.html path </param>
        /// <param name="skeletonPathName"> Auxiliary index.html </param>
        public static void CreateHtml(SerializableBindingList<Veicoli> objectList, string pathName, string skeletonPathName = @".\www\index-skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName);
            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE AUTOVALLAURI - VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "Le migliori occasioni al miglior prezzo!");
            

            string mainContent = "<h3> LISTA DEI VEICOLI DISPONIBILI </h3>";
            for (int i = 0; i < objectList.Count; i++)
                CreateBody(ref mainContent, objectList, i);

            html = html.Replace("{{main-content}}", mainContent);
            File.WriteAllText(pathName, html);
        }
        
        /// <summary>
        /// Create body for the html file
        /// </summary>
        /// <param name="mainContent"> Content to add </param>
        /// <param name="objectList"> List with datas </param>
        /// <param name="i"> List data position </param>
        private static void CreateBody(ref string mainContent, SerializableBindingList<Veicoli> objectList, int i)
        {
            string veicolo;
            string usato;
            string km0 = string.Empty;

            if (objectList[i].IsKmZero)
                km0 = "Chilometro zero<br>";
                

            if (objectList[i].IsUsato)
                usato = "Usato";
            else
                usato = "Nuovo";

            
            if (objectList[i] is Moto)
                veicolo = "moto.jpg";
            else
                veicolo = "auto.jpg";

            mainContent += "<div class = \"veicolo\">";
            mainContent += $"<img src = \"img/{veicolo}\">";
            mainContent += $"<div class = \"titolo\">{objectList[i].Marca} {objectList[i].Modello}";
            mainContent += $"<div class = \"didascalia\"> Colore: {objectList[i].Colore}<br> Cilindrata: {objectList[i].Cilindrata}<br> Immatricolazione: {objectList[i].Immatricolazione}<br> {km0} {usato}<br> Chilometri percorsi: {objectList[i].KmPercorsi}<br> Potenza: {objectList[i].PotenzaKw} <br> Prezzo: {objectList[i].Prezzo} </div>";
            mainContent += "</div>";
            mainContent += "</div>";
        }

        /// <summary>
        /// Update the db from json
        /// </summary>
        /// <param name="listaVeicoli"> List of vehicle </param>
        /// <param name="connStr"> String of connection </param>
        public static void UpdateDb(SerializableBindingList<Veicoli> listaVeicoli, string connStr)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    int autoId = 0;
                    int motoId = 0;
                    con.Open();

                    if (!ifExist("SELECT * FROM Auto", con)) DBUtilities.CreateTable("Auto");
                    if (!ifExist("SELECT * FROM Moto", con)) DBUtilities.CreateTable("Moto");
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    for (int i = 0; i < listaVeicoli.Count; i++)
                    {
                        if (listaVeicoli[i] is Auto)
                        {
                            autoId++;
                            if (ifExist($"SELECT * FROM Auto WHERE id={autoId}", con, true))
                            {
                                DBUtilities.Update("Auto", autoId, listaVeicoli[i].Marca,
                                    listaVeicoli[i].Modello, listaVeicoli[i].Colore, listaVeicoli[i].Cilindrata,
                                    listaVeicoli[i].PotenzaKw, listaVeicoli[i].Immatricolazione,
                                    listaVeicoli[i].IsUsato, listaVeicoli[i].IsKmZero, listaVeicoli[i].KmPercorsi,
                                    listaVeicoli[i].Prezzo, (listaVeicoli[i] as Auto).NumAirbag, "");
                            }
                            else
                            {
                                DBUtilities.AddNewItem("Auto", listaVeicoli[i].Marca,
                                    listaVeicoli[i].Modello, listaVeicoli[i].Colore, listaVeicoli[i].Cilindrata,
                                    listaVeicoli[i].PotenzaKw, listaVeicoli[i].Immatricolazione,
                                    listaVeicoli[i].IsUsato, listaVeicoli[i].IsKmZero, listaVeicoli[i].KmPercorsi,
                                    listaVeicoli[i].Prezzo, (listaVeicoli[i] as Auto).NumAirbag, "");
                            }
                        }
                        else
                        {
                            motoId++;
                            if (ifExist($"SELECT * FROM Moto WHERE id={motoId}", con, true))
                            {
                                DBUtilities.Update("Moto", motoId, listaVeicoli[i].Marca,
                                    listaVeicoli[i].Modello, listaVeicoli[i].Colore, listaVeicoli[i].Cilindrata,
                                    listaVeicoli[i].PotenzaKw, listaVeicoli[i].Immatricolazione,
                                    listaVeicoli[i].IsUsato, listaVeicoli[i].IsKmZero, listaVeicoli[i].KmPercorsi,
                                    listaVeicoli[i].Prezzo, 0, (listaVeicoli[i] as Moto).MarcaSella);
                            }
                            else
                            {
                                DBUtilities.AddNewItem("Moto", listaVeicoli[i].Marca,
                                    listaVeicoli[i].Modello, listaVeicoli[i].Colore, listaVeicoli[i].Cilindrata,
                                    listaVeicoli[i].PotenzaKw, listaVeicoli[i].Immatricolazione,
                                    listaVeicoli[i].IsUsato, listaVeicoli[i].IsKmZero, listaVeicoli[i].KmPercorsi,
                                    listaVeicoli[i].Prezzo, 0, (listaVeicoli[i] as Moto).MarcaSella);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check if table/record exists
        /// </summary>
        /// <param name="command"> Command string to execute </param>
        /// <param name="con"> Coonection to database </param>
        /// <param name="record"> true --> check the record existence; false --> check the table existence </param>
        /// <returns> true --> table/record exists; false --> table/record not exists </returns>
        private static bool ifExist(string command, OleDbConnection con, bool record = false)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;

                cmd.CommandText = command;
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                if (record)
                {
                    OleDbDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            rdr.Close();
                            return true;
                        }
                    }
                    rdr.Close();
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    #endregion
}
