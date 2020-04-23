using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopDLL;

namespace CarShop
{
    class Program
    {
        static void Main(string[] args)
        {
            char scelta;
            do
            {
                menu();
                Console.Write("DIGIT YOUR CHOICE ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        Console.Write("\nTable name: ");
                        string tableName = Console.ReadLine();
                        Utilities.CreateTableCars(tableName);
                        break;
                    case '2':
                        Console.Write("\nCar name: ");
                        string carName = Console.ReadLine();
                        Console.Write("Car price: ");
                        int carPrice = 0;
                        try
                        {
                            carPrice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Car price must be an integer!");
                            break;
                        }
                        Utilities.AddNewCar(carName, carPrice);
                        break;
                    case '3':
                        Utilities.ListCars();
                        break;
                    default:
                        break;
                }
            }
            while (scelta != 'X' && scelta != 'x');
        }

        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("*** CAR SHOP - DB MANAGEMENT ***\n");
            Console.WriteLine("1 - CREATE TABLE: Cars");
            Console.WriteLine("2 - ADD NEW ITEM: Cars");
            Console.WriteLine("3 - LIST: Cars");
            Console.WriteLine("4 - ...");
            Console.WriteLine("5 - ...");
            Console.WriteLine("\nX - END\n\n");
        }       
    }
}
