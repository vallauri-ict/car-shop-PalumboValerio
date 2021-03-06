﻿#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
#endregion

namespace CarShopDLLProject
{
    public class DBUtilities
    {
        #region Utilities
        public DBUtilities() { }
        public string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\CarShop.accdb";

        /// <summary>
        /// Create Auto or Moto table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        public void CreateTable(string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    // identity(1,1) auto-increment 
                    try
                    {
                        string command = $@"CREATE TABLE {tableName}(
                                id INT identity(1,1) NOT NULL PRIMARY KEY,
                                marca VARCHAR(255) NOT NULL, modello VARCHAR(255) NOT NULL,
                                colore VARCHAR(255), cilindrata INT, potenzaKw INT,
                                immatricolazione DATE, usato VARCHAR(255), kmZero VARCHAR(255),
                                kmPercorsi INT, prezzo MONEY,";
                        if (tableName == "Auto") command += " numAirbag INT,";
                        else command += " marcaSella VARCHAR(255),";
                        command += " img VARCHAR(255))";
                        cmd.CommandText = command;
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine($"\n\n{ex.Message}");
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }                    
                }
            }
        }

        /// <summary>
        /// Add new item in the correct table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        /// <param name="numAirbag"> Only for Auto </param>
        /// <param name="saddleBrand"> Only for Moto </param>
        public void AddNewItem(string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, double price, int numAirbag, string saddleBrand, string img = "noImage.png")
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    string command = string.Empty;
                    if (tableName == "Auto")
                        command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, numAirbag, img) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmDone, @price, @numAirbag, @img)";
                    else
                        command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, marcaSella, img) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmDone, @price, @saddleBrand, @img)";
                    cmd.CommandText = command;

                    string used = isUsed ? "Si" : "No";
                    string km0 = isKm0 ? "Si" : "No";
                    cmd.Parameters.Add(new OleDbParameter("@brand", OleDbType.VarChar, 255)).Value = brand;
                    cmd.Parameters.Add(new OleDbParameter("@model", OleDbType.VarChar, 255)).Value = model;
                    cmd.Parameters.Add(new OleDbParameter("@color", OleDbType.VarChar, 255)).Value = color;
                    cmd.Parameters.Add("@displacement", OleDbType.Integer).Value = displacement;
                    cmd.Parameters.Add("@powerKw", OleDbType.Integer).Value = powerKw;
                    cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = matriculation.ToShortDateString();
                    cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.VarChar, 255)).Value = used;
                    cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.VarChar, 255)).Value = km0;
                    cmd.Parameters.Add("@kmDone", OleDbType.Integer).Value = kmDone;
                    cmd.Parameters.Add("@price", OleDbType.Double).Value = price;
                    if (tableName == "Auto")
                        cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;
                    else
                        cmd.Parameters.Add(new OleDbParameter("@saddleBrand", OleDbType.VarChar, 255)).Value = saddleBrand;
                    cmd.Parameters.Add(new OleDbParameter("@img", OleDbType.VarChar, 255)).Value = img;
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Gave to the user the list of the element in the specific table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        public void ListTable(string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand command = new OleDbCommand($"SELECT * FROM {tableName}", con);

                    OleDbDataReader rdr = command.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        Console.WriteLine("\n");
                        while (rdr.Read())
                        {                            
                            string matriculation = rdr.GetDateTime(6).ToShortDateString();

                            string output = $"{rdr.GetInt32(0)} - {rdr.GetString(1)} - {rdr.GetString(2)} - " +
                                            $"{rdr.GetString(3)} - {rdr.GetInt32(4)} - {rdr.GetInt32(5)} - " +
                                            $"{matriculation} - {rdr.GetString(7)} - {rdr.GetString(8)} - " +
                                            $"{rdr.GetInt32(9)} - {rdr.GetDecimal(10)}";
                            if (tableName == "Auto") output += $" - {rdr.GetInt32(11)}";
                            else output += $" - {rdr.GetString(11)}";
                            Console.WriteLine(output);
                        }
                    }
                    else Console.WriteLine("\n\nNo rows found.");
                    rdr.Close();
                }
                System.Threading.Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// Update sql command
        /// </summary>
        /// <param name="id"> Identifier of the record that user wants to update </param>
        public void Update(string tableName, int id, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, double price, int numAirbag, string saddleBrand, string img = "")
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    string command = $"UPDATE {tableName}";
                    string set = " SET ";
                    set += parametersControl(brand != "-1", " marca=@brand");
                    set += parametersControl(model != "-1", " , modello=@model");
                    set += parametersControl(color != "-1", " , colore=@color");
                    set += parametersControl(displacement != -1, " , cilindrata=@displacement");
                    set += parametersControl(powerKw != -1, " , potenzaKw=@powerKw");
                    set += parametersControl(matriculation.ToString("dd/MM/yyyy") != "01/01/9999", " , immatricolazione=@matriculation");
                    set += " , usato=@isUsed";
                    set += " , kmZero=@isKm0";
                    set += parametersControl(kmDone != -1, " , kmPercorsi=@kmDone");
                    set += parametersControl(price != -1, " , prezzo=@price");                   
                    if (tableName=="Auto")
                        set += parametersControl(numAirbag != -1, " , numAirbag=@numAirbag");
                    else
                        set += parametersControl(saddleBrand != "-1", " , marcaSella=@saddleBrand");
                    set += parametersControl(img != "", " , img=@img");
                    if (set.Contains("SET  ,"))
                        set = set.Replace("SET  ,", "SET");
                    command += $" {set} WHERE id={id}";
                    cmd.CommandText = command;

                    string used = isUsed ? "Si" : "No";
                    string km0 = isKm0 ? "Si" : "No";
                    if (command.Contains("@brand"))
                        cmd.Parameters.Add(new OleDbParameter("@brand", OleDbType.VarChar, 255)).Value = brand;
                    if (command.Contains("@model"))
                        cmd.Parameters.Add(new OleDbParameter("@model", OleDbType.VarChar, 255)).Value = model;
                    if (command.Contains("@color"))
                        cmd.Parameters.Add(new OleDbParameter("@color", OleDbType.VarChar, 255)).Value = color;
                    if (command.Contains("@displacement"))
                        cmd.Parameters.Add("@displacement", OleDbType.Integer).Value = displacement;
                    if (command.Contains("@powerKw"))
                        cmd.Parameters.Add("@powerKw", OleDbType.Integer).Value = powerKw;
                    if (command.Contains("@matriculation"))
                        cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = matriculation.ToShortDateString();
                    if (command.Contains("@isUsed"))
                        cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.VarChar, 255)).Value = used;
                    if (command.Contains("@isKm0"))
                        cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.VarChar, 255)).Value = km0;
                    if (command.Contains("@kmDone"))
                        cmd.Parameters.Add("@kmDone", OleDbType.Integer).Value = kmDone;
                    if (command.Contains("@price"))
                        cmd.Parameters.Add("@price", OleDbType.Double).Value = price;
                    if (command.Contains("@numAirbag"))
                        cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;
                    if (command.Contains("@saddleBrand"))
                        cmd.Parameters.Add(new OleDbParameter("@saddleBrand", OleDbType.VarChar, 255)).Value = saddleBrand;
                    if (command.Contains("@img"))
                        cmd.Parameters.Add(new OleDbParameter("@img", OleDbType.VarChar, 255)).Value = img;
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();                   
                }
            }
        }

        /// <summary>
        /// A simple method to avoid repetitions in the code
        /// </summary>
        /// <param name="condition"> The if condition </param>
        /// <param name="rtn"> Returned string if condition is true  </param>
        /// <returns></returns>
        private string parametersControl(bool condition, string rtn)
        {
            if (condition) return rtn;
            else return "";
        }

        /// <summary>
        /// Delete sql command
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        /// <param name="id"> Identifier of the record that user wants to delete </param>
        public void Delete(string tableName, int id)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand($"DELETE FROM {tableName} WHERE id={id}", con);

                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Take the boolean fields actual velues
        /// </summary>
        /// <param name="parameter"> usato/kmZero </param>
        /// <param name="tableName"> Auto/Moto </param>
        /// <param name="id"> Identifier of the record that user wants to update </param>
        /// <returns></returns>
        public string takeActualValue(string parameter, string tableName, int id)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);

                using (con)
                {
                    con.Open();

                    OleDbCommand command = new OleDbCommand($"SELECT {parameter} FROM {tableName} WHERE id={id}", con);

                    OleDbDataReader rdr = command.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            return rdr.GetString(0);
                        }
                    }
                    else Console.WriteLine("\n\nNo rows found.");
                    rdr.Close();
                }
            }
            return "No";
        }

        /// <summary>
        /// Count the number of element in the specific table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        /// <returns></returns>
        public int ItemsCounter(string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                
                using (con)
                {
                    con.Open();

                    OleDbCommand command = new OleDbCommand($"SELECT MAX(id) FROM {tableName}", con);

                    OleDbDataReader rdr = command.ExecuteReader();
                    if(rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            return rdr.GetInt32(0);
                        }
                    }
                    else Console.WriteLine("\n\nNo rows found.");
                    rdr.Close();
                }
            }
            return -1;
        }

        /// <summary>
        /// Delete the all specific table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        public void DropTable(string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    string command = $"DROP TABLE {tableName}";
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Create a backup of the db
        /// </summary>
        public void CreateBackup(string dbFilePath)
        {
            string backupDBFilePath = dbFilePath.Replace("CarShop.accdb", "BackupCarShop.accdb");
            if (File.Exists(backupDBFilePath)) File.Delete(backupDBFilePath);
            File.Copy(dbFilePath, backupDBFilePath);
        }

        /// <summary>
        /// Restrore the db Backup
        /// </summary>
        public void RestoresBackup(string dbFilePath)
        {
            string backupDBFilePath = dbFilePath.Replace("CarShop.accdb", "BackupCarShop.accdb");
            if (File.Exists(dbFilePath)) File.Delete(dbFilePath);
            File.Copy(backupDBFilePath, dbFilePath);
        }
        #endregion
    }
}
