using System;
using VenditaVeicoliDLLProject;

namespace ConsoleAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** SALONE VENDITA VEICOLI NUOVI E USATI ***");
            Moto m = new Moto();
            Auto a = new Auto();
            Console.WriteLine(m.ToString());
            Console.WriteLine(a.ToString());
        }
    }
}
