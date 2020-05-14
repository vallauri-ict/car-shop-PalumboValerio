#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using CarShopDLLProject;
#endregion

namespace ConsoleAppProject
{
    class Program
    {
        #region Initializations
        public static DBUtilities dbUtilities = new DBUtilities();

        public static string dbFilePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\CarShop.accdb";
        public static string table, brand, model, color, saddleBrand;
        public static int id, displacement, kmDone, numAirbag;
        public static double powerKw, price;
        public static bool isUsed, isKm0;
        public static DateTime matriculation;
        #endregion
        static void Main(string[] args)
        {
            #region Main
            char choice;
            do
            {
                menu();
                Console.Write("DIGIT YOUR CHOICE ");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        table = vehicle();
                        if (table != "x")
                        {
                            dbUtilities.CreateTable(table);
                            Console.WriteLine("\nTable created");
                            Thread.Sleep(3000);
                        }
                        break;
                    case '2':
                        table = vehicle();
                        if (table != "x")
                        {
                            takeParameters();
                            dbUtilities.AddNewItem(table, brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmDone, price, numAirbag, saddleBrand);
                            Console.WriteLine("\nNew item added corectly");
                            Thread.Sleep(3000);
                        }                            
                        break;
                    case '3':
                        table = vehicle();
                        if (table != "x") dbUtilities.ListTable(table);
                        break;
                    case '4':
                        table = vehicle();
                        if (table != "x")
                        {
                            id = takeId(table);
                            takeParameters();
                            dbUtilities.Update(table, id, brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmDone, price, numAirbag, saddleBrand);
                            id = 0;
                            Console.WriteLine($"\nTable {table} updated");
                            Thread.Sleep(3000);
                        }
                        break;
                    case '5':
                        table = vehicle();
                        if (table != "x")
                        {
                            id = takeId(table);
                            dbUtilities.Delete(table, id);
                            id = 0;
                            Console.WriteLine("\nItem removed corectly");
                            Thread.Sleep(3000);
                        }
                        break;
                    case '6':
                        table = vehicle();
                        if (table != "x")
                        {
                            dbUtilities.DropTable(table);
                            Console.WriteLine($"\nTable {table} removed");
                            Thread.Sleep(3000);
                        }
                        break;
                    case '7':
                        dbUtilities.CreateBackup(dbFilePath);
                        Console.WriteLine($"\nBackup created");
                        Thread.Sleep(3000);
                        break;
                    case '8':
                        dbUtilities.RestoresBackup(dbFilePath);
                        Console.WriteLine($"\nBackup restored");
                        Thread.Sleep(3000);
                        break;
                    default:
                        break;
                }
            }
            while (choice != 'X' && choice != 'x');
            #endregion
        }

        #region methods
        /// <summary>
        /// Create the menù list
        /// </summary>
        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("*** AUTOPALU - DB MANAGEMENT ***\n");
            Console.WriteLine("1 - CREATE TABLE");
            Console.WriteLine("2 - ADD NEW ITEM");
            Console.WriteLine("3 - LIST");
            Console.WriteLine("4 - UPDATE ITEM");
            Console.WriteLine("5 - DELETE ITEM");
            Console.WriteLine("6 - DROP TABLE"); 
            Console.WriteLine("7 - CREATE DB BACKUP");
            Console.WriteLine("8 - RESTORES DB BACKUP");
            Console.WriteLine("\nX - END\n\n");
        }

        /// <summary>
        /// Take all the needed parameters - useful to streamline the main -
        /// </summary>
        /// <param name="table"> Table name where user wants to add new item </param>
        private static void takeParameters()
        {
            // Take brand parameter - string -
            Console.Write("\nBrand: ");
            brand = Console.ReadLine();
            // Take model parameter - string -
            Console.Write("Model: ");
            model = Console.ReadLine();
            // Take color parameter - string -
            Console.Write("Color: ");
            color = Console.ReadLine();
            // Take displacement parameter with a type controll - integer -
            displacement = Convert.ToInt32(typeVerifier("Displacement: "));
            // Take powerKw parameter with a type controll - double -
            powerKw = Convert.ToDouble(typeVerifier("Power: ", "double"));
            // Take matriculation parameter with a type controll - date -
            matriculation = dateVerifier("Matriculation: ");
            // Take isUsed parameter with a type controll - bool -
            isUsed = boolRequest("Used");
            // Take isKm0 parameter with a type controll - bool -
            isKm0 = boolRequest("Km Zero");
            // Take kmPercorsi parameter with a type controll - integer -
            kmDone = Convert.ToInt32(typeVerifier("Km Done: "));
            // Take price parameter with a type controll - integer -
            price = Convert.ToInt32(typeVerifier("Price: ", "double"));
            // Take the specific parameter depending on the type of vehicle - Auto/Moto -
            numAirbag = -1;
            saddleBrand = string.Empty;
            if (table == "Auto") numAirbag = Convert.ToInt32(typeVerifier("numAirbag: "));
            else
            {
                Console.Write("Saddle Brand: ");
                saddleBrand = Console.ReadLine();
            }
        }

        /// <summary>
        /// Table/Vehicle type choice
        /// </summary>
        /// <returns> "Auto"/"Moto" </returns>
        private static string vehicle()
        {
            char table;
            do
            {
                Console.WriteLine("\na- Auto (Cars)");
                Console.WriteLine("m- Moto (Motorbikes)");
                Console.WriteLine("X - CANCEL\n");
                Console.Write("Choose a table: ");
                table = Console.ReadKey().KeyChar;
            } while (table != 'a' && table != 'A' && table != 'm' && table != 'M' && table!='x' && table!='X');

            if (table == 'a' || table == 'A') return "Auto";
            else if (table == 'm' || table == 'M') return "Moto";
            else return "x";
        }

        /// <summary>
        /// Verifier if the user input data type is correct or not
        /// </summary>
        /// <param name="consoleWrite"> String in the Console.Write </param>
        /// <param name="verifier"> Type to check - int or double - </param>
        /// <returns></returns>
        private static object typeVerifier(string consoleWrite, string verifier = "integer")
        {
            int iVerifier = 0;
            double dVerifier = 0;
            do
            {
                Console.Write(consoleWrite);
                try
                {
                    if (verifier == "integer") iVerifier = Convert.ToInt32(Console.ReadLine());
                    else dVerifier = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine($"This input must be an {verifier}!");
                    if (verifier == "integer") iVerifier = -2;
                    else dVerifier = -2;
                }
            } while (iVerifier == -2 || dVerifier == -2);

            if (verifier == "integer")
                return iVerifier;
            else
                return dVerifier;
        }

        /// <summary>
        /// Type bool data verification
        /// </summary>
        /// <param name="consoleWrite"> String in the Console.Write </param>
        /// <returns> true/false </returns>
        private static bool boolRequest(string consoleWrite)
        {
            string answer;
            string parameter;
            if (consoleWrite == "Used") parameter = "usato";
            else parameter = "kmZero";
            do
            {
                Console.Write($"{consoleWrite} Y/N: ");
                answer = Console.ReadLine();
            } while (answer != "Y" && answer != "N" && answer != "y" && answer != "n" && answer != "-1");

            if (answer == "Y" || answer == "y") return true;
            else if (answer == "N" || answer == "n") return false;
            else if (dbUtilities.takeActualValue(parameter, table, id) == "Si") return true;
            else return false;
        }

        /// <summary>
        /// Type DateTime data verification
        /// </summary>
        /// <param name="consoleWrite"> String in the Console.Write </param>
        /// <returns> User input date </returns>
        private static DateTime dateVerifier(string consoleWrite)
        {
            DateTime verifier = DateTime.Now;
            bool correct;
            do
            {
                Console.Write(consoleWrite);
                try
                {
                    string aus = Console.ReadLine();
                    if (aus == "-1") aus = "01/01/9999";
                    verifier = Convert.ToDateTime(aus);
                    correct = true;
                }
                catch (Exception)
                {
                    correct = false;
                }
            } while (!correct);

            return verifier;
        }

        /// <summary>
        /// Take the id of a record
        /// </summary>
        /// <param name="table"> Auto/Moto </param>
        /// <returns></returns>
        private static int takeId(string table)
        {
            int maxId = dbUtilities.ItemsCounter(table);
            int id;
            do
            {
                id = Convert.ToInt32(typeVerifier($"\nInsert a number form 1 to {maxId}: "));
            } while (id < 1 || id > maxId);

            return id;
        }
        #endregion
    }
}