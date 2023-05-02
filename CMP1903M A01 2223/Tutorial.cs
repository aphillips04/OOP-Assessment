using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Tutorial
    {
        public static void Tutor()
        {
            Console.WriteLine("Welcome to the mathematics tutorial program.");
            Menu();
            Console.WriteLine("Thank you for using the mathematics tutorial program.");
        }
        static void Menu()
        {
            Console.WriteLine(
               "1) Instructions\n" +
               "2) Deal 3 cards (2 numbers, 1 operator)\n" +
               "3) Deal 5 cards (3 numbers, 2 operators)\n" +
               "4) Quit"
            );
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Instructions");
            }
            else if (choice == "4")
            {
                return;
            }
            else if ((new string[] { "2", "3" }).Contains(choice))
            {
                while (true)
                {
                    Pack pack = new Pack();
                    pack.shuffleCardPack(1);
                    List<Card> values = pack.dealCard(3);
                    DataTable cmp = new DataTable();
                    string[] ops = new string[] { "+", "-", "*", "/" };
                    string expr = $"{values[0].Value} {ops[values[1].Suit - 1]} {values[2].Value}";
                    if (choice == "3")
                    {
                        values = pack.dealCard(2);
                        expr += $" {ops[values[0].Suit - 1]} {values[1].Value}";
                    }
                    Console.Write(expr + " = ");
                    double answer = Convert.ToDouble(cmp.Compute(expr, ""));
                    double input;
                    while (true)
                    {
                        try { input = Convert.ToDouble(Console.ReadLine()); break; }
                        catch (FormatException) { Console.WriteLine($"Invalid Answer. Try Again!\n{expr} = "); }
                    }
                    answer = Math.Round(answer, 2);
                    if (input == answer) Console.WriteLine("Correct.");
                    else Console.WriteLine($"Incorrect. The right answer was {answer}.");
                    Console.Write("Deal again? (Y/n) ");
                    if (Console.ReadLine().ToLower() == "n") break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Option.");
            }
            Menu();
        }
    }
}
