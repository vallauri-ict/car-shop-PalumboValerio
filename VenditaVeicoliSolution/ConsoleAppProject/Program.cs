#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VenditaVeicoliDLLProject;
#endregion

namespace ConsoleAppProject
{
    class Program
    {
        #region Initializations
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
                        DBUtilities.CreateTable(table);
                        break;
                    case '2':
                        table = vehicle();
                        takeParameters();
                        DBUtilities.AddNewItem(table, brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmDone, price, numAirbag, saddleBrand);
                        break;
                    case '3':
                        table = vehicle();
                        DBUtilities.ListTable(table);
                        break;
                    case '4':
                        table = vehicle();
                        id = takeId(table);
                        takeParameters();
                        DBUtilities.Update(table, id, brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmDone, price, numAirbag, saddleBrand);
                        id = 0;
                        break;
                    case '5':
                        table = vehicle();
                        id = takeId(table);
                        DBUtilities.Delete(table, id);
                        break;
                    case '6':
                        table = vehicle();
                        DBUtilities.DropTable(table);
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
            Console.WriteLine("*** SALONE VENDITA VEICOLI NUOVI E USATI - DB MANAGEMENT ***\n");
            Console.WriteLine("1 - CREATE TABLE");
            Console.WriteLine("2 - ADD NEW ITEM");
            Console.WriteLine("3 - LIST");
            Console.WriteLine("4 - UPDATE ITEM");
            Console.WriteLine("5 - DELETE ITEM");
            Console.WriteLine("6 - DROP TABLE");
            Console.WriteLine("\nX - END\n\n");
        }

        /// <summary>
        /// Take all the needed parameters - useful to streamline the main -
        /// </summary>
        /// <param name="table"> Table name where user wants to add new item </param>
        private static void takeParameters()
        {
            // Take brand parameter - string -
            Console.Write("\nmarca: ");
            brand = Console.ReadLine();
            // Take model parameter - string -
            Console.Write("modello: ");
            model = Console.ReadLine();
            // Take color parameter - string -
            Console.Write("colore: ");
            color = Console.ReadLine();
            // Take displacement parameter with a type controll - integer -
            displacement = Convert.ToInt32(typeVerifier("cilindrata: "));
            // Take powerKw parameter with a type controll - double -
            powerKw = Convert.ToDouble(typeVerifier("potenzaKw: ", "double"));
            // Take matriculation parameter with a type controll - date -
            matriculation = dateVerifier("immatricolazione: ");
            // Take isUsed parameter with a type controll - bool -
            isUsed = boolRequest("usato");
            // Take isKm0 parameter with a type controll - bool -
            isKm0 = boolRequest("kmZero");
            // Take kmPercorsi parameter with a type controll - integer -
            kmDone = Convert.ToInt32(typeVerifier("kmPercorsi: "));
            // Take price parameter with a type controll - integer -
            price = Convert.ToInt32(typeVerifier("prezzo: ", "double"));
            // Take the specific parameter depending on the type of vehicle - Auto/Moto -
            numAirbag = -1;
            saddleBrand = string.Empty;
            if (table == "Auto") numAirbag = Convert.ToInt32(typeVerifier("numAirbag: "));
            else
            {
                Console.Write("marcaSella: ");
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
                Console.WriteLine("\na- Auto");
                Console.WriteLine("m- Moto");
                Console.Write("Choose a table: ");
                table = Console.ReadKey().KeyChar;
            } while (table != 'a' && table != 'm');

            if (table == 'a') return "Auto";
            else return "Moto";
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
            do
            {
                Console.Write($"{consoleWrite} Y/N: ");
                answer = Console.ReadLine();
            } while (answer != "Y" && answer != "N" && answer != "y" && answer != "n" && answer != "-1");

            if (answer == "Y" || answer == "y") return true;
            else if (answer == "N" || answer == "n") return false;
            else return DBUtilities.takeActualValue(consoleWrite, table, id);
        }

        /// <summary>
        /// Type DateTime data verification
        /// </summary>
        /// <param name="consoleWrite"> String in the Console.Write </param>
        /// <returns> User input date </returns>
        private static DateTime dateVerifier(string consoleWrite)
        {
            DateTime verifier = DateTime.Now;
            bool correct = true;
            do
            {
                Console.Write(consoleWrite);
                try
                {
                    string aus = Console.ReadLine();
                    if (aus == "-1") aus = "01/01/9999";
                    verifier = Convert.ToDateTime(aus);
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
            int maxId = DBUtilities.ItemsCounter(table);
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