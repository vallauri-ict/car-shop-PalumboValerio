using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace CarShopDLL
{
    public class Utilities
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

                    // DropTable(cmd, "cars");

                    // identity(1,1) auto-increment 
                    try
                    {
                        string command = @"CREATE TABLE @table(
                                id INT identity(1,1) NOT NULL PRIMARY KEY,
                                name VARCHAR(255) NOT NULL,
                                price INT)";
                        command = command.Replace("@table", tableName);
                        cmd.CommandText = command;
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine($"\n\n{ex.Message}");
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    Insert(con, "cars", "Audi", 52642);
                    Insert(con, "cars", "Mercedes", 57127);
                    Insert(con, "cars", "Skoda", 9000);
                    Insert(con, "cars", "Volvo", 29000);
                    Insert(con, "cars", "Bentley", 350000);
                    Insert(con, "cars", "Citroen", 21000);
                    Insert(con, "cars", "Hummer", 41400);
                    Insert(con, "cars", "Volkswagen", 21600);

                    Console.WriteLine("\nTable created with test data");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public static void AddNewCar(string carName, int carPrice)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    Insert(con, "cars", carName, carPrice);

                    Console.WriteLine("\nNew item added corectly");
                    System.Threading.Thread.Sleep(3000);
                }

            }
        }

        public static void ListCars()
        {
            if (connStr != null)
            {
                OleDbConnection connection = new OleDbConnection(connStr);
                using (connection)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand("SELECT * FROM cars", connection);

                    OleDbDataReader rdr = command.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        Console.WriteLine("\n");
                        while (rdr.Read())
                        {
                            Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1),
                                rdr.GetInt32(2));
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

        public static void Insert(OleDbConnection con, string tableName, string carName, int carPrice)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            string command = "INSERT INTO @table(name, price) VALUES(@name, @price)";
            command = command.Replace("@table", tableName);
            cmd.CommandText = command;

            cmd.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255)).Value = carName;
            cmd.Parameters.Add("@price", OleDbType.Integer).Value = carPrice;
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
                    string command = $"DROP TABLE IF EXIST @table";
                    command = command.Replace("@table", tableName);
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
