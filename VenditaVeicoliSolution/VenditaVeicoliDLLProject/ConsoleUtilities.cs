using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace VenditaVeicoliDLLProject
{
    public class ConsoleUtilities
    {
        public static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CarShop.accdb";

        /// <summary>
        /// Create Auto or Moto table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        public static void CreateTable(string tableName)
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
                                immatricolazione DATE, usato BIT, kmZero BIT,
                                kmPercorsi INT, prezzo INT,";
                        if (tableName == "Auto") command += " numAirbag INT)";
                        else command += " marcaSella VARCHAR(255))";
                        cmd.CommandText = command;
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine($"\n\n{ex.Message}");
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    Console.WriteLine("\nTable created");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        /// <summary>
        /// Add new item in the correct table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        /// <param name="numAirbag"> Only for Auto </param>
        /// <param name="saddleBrand"> Only for Moto </param>
        public static void AddNewItem(string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, int price, int numAirbag, string saddleBrand)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    Insert(con, tableName, brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmDone, price, numAirbag, saddleBrand);

                    Console.WriteLine("\nNew item added corectly");
                    System.Threading.Thread.Sleep(3000);
                }

            }
        }

        /// <summary>
        /// Insert sql command
        /// </summary>
        private static void Insert(OleDbConnection con, string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, int price, int numAirbag, string saddleBrand)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            string command = string.Empty;
            if (tableName == "Auto")
                command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, numAirbag) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmDone, @price, @numAirbag)";
            else
                command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, marcaSella) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmDone, @price, @saddleBrand)";
            cmd.CommandText = command;

            cmd.Parameters.Add(new OleDbParameter("@brand", OleDbType.VarChar, 255)).Value = brand;
            cmd.Parameters.Add(new OleDbParameter("@model", OleDbType.VarChar, 255)).Value = model;
            cmd.Parameters.Add(new OleDbParameter("@color", OleDbType.VarChar, 255)).Value = color;
            cmd.Parameters.Add("@displacement", OleDbType.Integer).Value = displacement;
            cmd.Parameters.Add("@powerKw", OleDbType.Integer).Value = powerKw;
            cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = matriculation;
            cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.Boolean)).Value = isUsed;
            cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.Boolean)).Value = isKm0;
            cmd.Parameters.Add("@kmDone", OleDbType.Integer).Value = kmDone;
            cmd.Parameters.Add("@price", OleDbType.Integer).Value = price;
            if (tableName == "Auto")
                cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;
            else
                cmd.Parameters.Add(new OleDbParameter("@saddleBrand", OleDbType.VarChar, 255)).Value = saddleBrand;
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gave to the user the list of the element in the specific table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        public static void ListTable(string tableName)
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
                            string matriculation = rdr.GetDateTime(6).ToString("dd/MM/yyyy");
                            string boolean = ifElse(rdr.GetBoolean(7), "usato -", "non usato -");
                            boolean += ifElse(rdr.GetBoolean(8), " km zero", " non km zero");

                            string output = $"{rdr.GetInt32(0)} - {rdr.GetString(1)} - {rdr.GetString(2)} - " +
                                            $"{rdr.GetString(3)} - {rdr.GetInt32(4)} - {rdr.GetInt32(5)} - " +
                                            $"{matriculation} - {boolean} - {rdr.GetInt32(9)} - " +
                                            $"{rdr.GetInt32(10)}";
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
        /// A simple method to avoid repetitions in the code
        /// </summary>
        /// <param name="condition"> The if condition </param>
        /// <param name="trueStr"> Returned string if condition is true </param>
        /// <param name="falseStr"> Returned string if condition is false </param>
        /// <returns></returns>
        private static string ifElse(bool condition, string trueStr, string falseStr)
        {
            if (condition) return trueStr;
            else return falseStr;
        }

        /// <summary>
        /// Update sql command
        /// </summary>
        /// <param name="id"> Identifier of the record that user wants to update </param>
        public static void Update(string tableName, int id, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, int price, int numAirbag, string saddleBrand)
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
                    if(tableName=="Auto")
                        set += parametersControl(numAirbag != -1, " , numAirbag=@numAirbag");
                    else
                        set += parametersControl(saddleBrand != "-1", " , marcaSella=@saddleBrand");
                    if(set.Contains("SET  ,"))
                        set = set.Replace("SET  ,", "SET");
                    command += $" {set} WHERE id={id}";
                    cmd.CommandText = command;

                    if(command.Contains("@brand"))
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
                        cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = matriculation;
                    if (command.Contains("@isUsed"))
                        cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.Boolean)).Value = isUsed;
                    if (command.Contains("@isKm0"))
                        cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.Boolean)).Value = isKm0;
                    if (command.Contains("@kmDone"))
                        cmd.Parameters.Add("@kmDone", OleDbType.Integer).Value = kmDone;
                    if (command.Contains("@price"))
                        cmd.Parameters.Add("@price", OleDbType.Integer).Value = price;
                    if (command.Contains("@numAirbag"))
                        cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;
                    if (command.Contains("@saddleBrand"))
                        cmd.Parameters.Add(new OleDbParameter("@saddleBrand", OleDbType.VarChar, 255)).Value = saddleBrand;
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"\nTable {tableName} updated");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        /// <summary>
        /// A simple method to avoid repetitions in the code
        /// </summary>
        /// <param name="condition"> The if condition </param>
        /// <param name="rtn"> Returned string if condition is true  </param>
        /// <returns></returns>
        private static string parametersControl(bool condition, string rtn)
        {
            if (condition) return rtn;
            else return "";
        }

        /// <summary>
        /// Delete sql command
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        /// <param name="id"> Identifier of the record that user wants to delete </param>
        public static void Delete(string tableName, int id)
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
                    Console.WriteLine("\nItem removed corectly");
                    System.Threading.Thread.Sleep(3000);
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
        public static bool takeActualValue(string parameter, string tableName, int id)
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
                            return rdr.GetBoolean(0);
                        }
                    }
                    else Console.WriteLine("\n\nNo rows found.");
                    rdr.Close();
                }
            }
            return false;
        }

        /// <summary>
        /// Count the number of element in the specific table
        /// </summary>
        /// <param name="tableName"> Auto/Moto </param>
        /// <returns></returns>
        public static int ItemsCounter(string tableName)
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
        public static void DropTable(string tableName)
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
                    Console.WriteLine($"\nTable {tableName} removed");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }
    }
}
