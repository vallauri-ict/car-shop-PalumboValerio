using System;
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
            while (choice != 'X' && choice != 'x');
        }
    }
}
