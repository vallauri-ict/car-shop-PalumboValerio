using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenditaVeicoliDLLProject;

namespace ConsoleAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** SALONE VENDITA VEICOLI NUOVI E USATI ***");
            char choice;
            do
            {
                menu();
                Console.Write("DIGIT YOUR CHOICE ");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        string table = vehicle();
                        ConsoleUtilities.CreateTableCars(table);
                        break;
                    case '2':
                        table = vehicle();
                        takeParameters(table);                       
                        break;
                    case '3':
                        table = vehicle();
                        ConsoleUtilities.ListCars(table);
                        break;
                    case '4':
                        table = vehicle();
                        ConsoleUtilities.DropTable(table);
                        break;
                    default:
                        break;
                }
            }
            while (choice != 'X' && choice != 'x');
        }

        private static void takeParameters(string table)
        {
            Console.Write("\nmarca: ");
            string brand = Console.ReadLine();

            Console.Write("modello: ");
            string model = Console.ReadLine();

            Console.Write("colore: ");
            string color = Console.ReadLine();

            int displacement = Convert.ToInt32(typeVerifier("cilindrata: "));

            double powerKw = Convert.ToDouble(typeVerifier("potenzaKw: ", "double"));

            DateTime matriculation = dateVerifier("immatricolazione: ");

            bool isUsed = boolRequest("usato");

            bool isKm0 = boolRequest("kmZero");

            int kmPercorsi = Convert.ToInt32(typeVerifier("kmPercorsi: "));

            int price = Convert.ToInt32(typeVerifier("prezzo: "));

            int numAirbag = -1;
            string saddleBrand = string.Empty;
            if (table == "Auto")
            {
                numAirbag = Convert.ToInt32(typeVerifier("numAirbag: "));
            }
            else
            {
                Console.Write("marcaSella: ");
                saddleBrand = Console.ReadLine();
            }

            ConsoleUtilities.AddNewCar(table, brand, model, color, displacement, powerKw, matriculation, isUsed, isKm0, kmPercorsi, price, numAirbag, saddleBrand);
        }

        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("*** CAR SHOP - DB MANAGEMENT ***\n");
            Console.WriteLine("1 - CREATE TABLE");
            Console.WriteLine("2 - ADD NEW ITEM");
            Console.WriteLine("3 - LIST");
            Console.WriteLine("4 - DROP TABLE");
            Console.WriteLine("5 - MODIFY ITEMS");
            Console.WriteLine("\nX - END\n\n");
        }

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

        private static object typeVerifier(string consoleWrite, string verifier = "integer")
        {
            int iVerifier = 0;
            double dVerifier = 0;
            do
            {
                Console.Write(consoleWrite);
                try
                {
                    if (verifier == "integer")
                        iVerifier = Convert.ToInt32(Console.ReadLine());
                    else
                        dVerifier = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine($"This input must be an {verifier}!");
                    iVerifier = -1;
                    dVerifier = -1;
                }
            } while (iVerifier == -1 && dVerifier == -1);

            if (verifier == "integer")
                return iVerifier;
            else
                return dVerifier;
        }

        private static bool boolRequest(string consoleWrite)
        {
            string answer;
            do
            {
                Console.Write($"{consoleWrite} Y/N: ");
                answer = Console.ReadLine();
            } while (answer != "Y" && answer != "N" && answer != "y" && answer != "n");

            if (answer == "Y" || answer == "y")
                return true;
            else
                return false;
        }

        private static DateTime dateVerifier(string consoleWrite)
        {
            DateTime verifier = DateTime.Now;
            bool correct = true;
            do
            {
                Console.Write(consoleWrite);
                try
                {
                    verifier = Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception)
                {
                    correct = false;
                }
            } while (!correct);

            return verifier;
        }
    }
}