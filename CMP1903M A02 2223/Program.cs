using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the mathematics tutorial program.");
            Menu();
            Console.WriteLine("Thank you for using the mathematics tutorial program.");
        }

        static void Menu()
        {
            Console.WriteLine(String.Join("\n", new string[] {
                "1) Instructions",
                "2) Deal 3 cards (2 numbers, 1 operator)",
                "3) Deal 5 cards (3 numbers, 2 operators)",
                "4) Quit"
            }));
            switch ( Console.ReadLine() )
            {
                case "1":
                    Tutorial.Instructions();
                    break;
                case "2":
                    Tutorial.Tutor(3);
                    break;
                case "3":
                    Tutorial.Tutor(5);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
            Menu();
        }
    }
}
