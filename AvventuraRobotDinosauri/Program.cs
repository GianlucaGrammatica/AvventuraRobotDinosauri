using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraRobotDinosauri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int NumeroDinosauri;
            int NumeroRobot;

            Console.WriteLine("Inserisci il numero di Dinosauri: ");
            NumeroDinosauri = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nInserisci il numero di Robot: ");
            NumeroRobot = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nPremi un tasto per iniziare");
            Console.ReadKey();

            RobotDinosauri robotDinosauri = new RobotDinosauri(NumeroDinosauri, NumeroRobot);
            robotDinosauri.Run();

            Console.ReadKey();
        }
    }
}
