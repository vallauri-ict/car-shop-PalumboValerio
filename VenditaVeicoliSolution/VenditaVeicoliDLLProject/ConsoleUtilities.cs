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

        public static void CreateTableCars(string tableName)
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
                        string command;
                        if (tableName == "Auto")
                        {
                            command = @"CREATE TABLE Auto(
                                id INT identity(1,1) NOT NULL PRIMARY KEY,
                                marca VARCHAR(255) NOT NULL, modello VARCHAR(255) NOT NULL,
                                colore VARCHAR(255), cilindrata INT, potenzaKw INT,
                                immatricolazione DATE, usato BIT, kmZero BIT,
                                kmPercorsi INT, prezzo INT, numAirbag INT)";
                        }
                        else
                        {
                            command = @"CREATE TABLE Moto(
                                id INT identity(1,1) NOT NULL PRIMARY KEY,
                                marca VARCHAR(255) NOT NULL, modello VARCHAR(255) NOT NULL,
                                colore VARCHAR(255), cilindrata INT, potenzaKw INT,
                                immatricolazione DATE, usato BIT NOT NULL CHECK, kmZero BIT NOT NULL CHECK,
                                kmPercorsi INT, prezzo INT, marcaSella VARCHAR(255))";
                        }
                        cmd.CommandText = command;
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine($"\n\n{ex.Message}");
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    /*Insert(con, "cars", "Audi", 52642);
                    Insert(con, "cars", "Mercedes", 57127);
                    Insert(con, "cars", "Skoda", 9000);
                    Insert(con, "cars", "Volvo", 29000);
                    Insert(con, "cars", "Bentley", 350000);
                    Insert(con, "cars", "Citroen", 21000);
                    Insert(con, "cars", "Hummer", 41400);
                    Insert(con, "cars", "Volkswagen", 21600);*/

                    Console.WriteLine("\nTable created");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public static void AddNewCar(string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmPercorsi, int price, int numAirbag, string saddleBrand)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    Insert(con, tableName, brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmPercorsi, price, numAirbag, saddleBrand);

                    Console.WriteLine("\nNew item added corectly");
                    System.Threading.Thread.Sleep(3000);
                }

            }
        }

        public static void ListCars(string tableName)
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
                            if (tableName == "Auto")
                            {
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}", rdr.GetInt32(0), rdr.GetString(1),
                                rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4), rdr.GetInt32(5),
                                rdr.GetDateTime(6), rdr.GetBoolean(7), rdr.GetBoolean(8), rdr.GetInt32(9),
                                rdr.GetInt32(10), rdr.GetInt32(11));
                            }
                            else
                            {
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}", rdr.GetInt32(0), rdr.GetString(1),
                                rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4), rdr.GetInt32(5),
                                rdr.GetDateTime(6), rdr.GetBoolean(7), rdr.GetBoolean(8), rdr.GetInt32(9),
                                rdr.GetInt32(10), rdr.GetString(11));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nNo rows found.");
                    }
                    rdr.Close();
                }
                System.Threading.Thread.Sleep(5000);
            }
        }

        public static void Insert(OleDbConnection con, string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmPercorsi, int price, int numAirbag, string saddleBrand)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            string command = string.Empty;
            if (tableName == "Auto")
                command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, numAirbag) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmPercorsi, @price, @numAirbag)";
            else
                command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, numAirbag) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmPercorsi, @price, @saddleBrand)";
            cmd.CommandText = command;

            cmd.Parameters.Add(new OleDbParameter("@brand", OleDbType.VarChar, 255)).Value = brand;
            cmd.Parameters.Add(new OleDbParameter("@model", OleDbType.VarChar, 255)).Value = model;
            cmd.Parameters.Add(new OleDbParameter("@color", OleDbType.VarChar, 255)).Value = color;
            cmd.Parameters.Add("@displacement", OleDbType.Integer).Value = displacement;
            cmd.Parameters.Add("@powerKw", OleDbType.Integer).Value = powerKw;
            cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = matriculation;
            cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.Boolean)).Value = isUsed;
            cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.Boolean)).Value = isKm0;
            cmd.Parameters.Add("@kmPercorsi", OleDbType.Integer).Value = kmPercorsi;
            cmd.Parameters.Add("@price", OleDbType.Integer).Value = price;
            if (tableName == "Auto")
                cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;
            else
                cmd.Parameters.Add(new OleDbParameter("@saddleBrand", OleDbType.VarChar, 255)).Value = saddleBrand;
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }



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
