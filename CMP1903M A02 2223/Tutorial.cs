using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
{
    class Tutorial
    {
        public static void Instructions()
        {
            Console.WriteLine(String.Join("\n", new string[] {
                "",
                "Instructions:",
                "To start, select from the options of either performing a single operation on 2 numbers (easy)",
                "or perfoming two operations on 3 numbers (hard). You will then be prompted with an expression",
                "answer that expression abiding by the rules of BODMAS/BIDMAS/PEMDAS (or equivalent).",
                "E.g.",
                "    2 - 12 / 3 = ",
                "    (We do the divion first)",
                "    2 - 4 = ",
                "    2 - 4 = -2",
                ""
            }));
        }

        public static void Tutor(int amount)
        {
            Console.WriteLine();
            // Pre-initalise the variables to save time
            Func<string, string, object> Compute = (new DataTable()).Compute;
            string[] ops = new string[] { "+", "-", "*", "/" };
            Pack pack;
            List<Card> values;
            string expr;
            double answer, input;

            while (true)
            {
                // Create new pack, deal the cards
                pack = new Pack();
                pack.shuffleCardPack(1);
                values = pack.dealCard(amount);

                // Generate the expression and compute the correct answer
                expr = "";
                for (int i = 0; i < values.Count; i++) expr += (i % 2 == 0) ? $"{values[i].Value} " : $"{ops[values[i].Suit - 1]} ";
                answer = Convert.ToDouble(Compute(expr, ""));
                answer = Round(answer, 2);

                // Ask the user to provide their answer to the expression, only allowed valid answers
                Console.Write(expr + "= ");
                while (true)
                {
                    try { input = Convert.ToDouble(Console.ReadLine()); break; } // Signed double to allow for floating point and negatives
                    catch (FormatException) { Console.Write($"Invalid Answer. Try Again!\n{expr} = "); }
                }
                
                // Save question data to stats file and tell the user if they were correct, providing the correct answer if they weren't
                File.AppendAllText("stats.txt", $"{expr} = {input} [{answer}] ");
                if (input == answer) { Console.WriteLine("Correct."); File.AppendAllText("stats.txt", "✓"); }
                else { Console.WriteLine($"Incorrect. The right answer was {answer}."); File.AppendAllText("stats.txt", "✗"); }
                File.AppendAllText("stats.txt", Environment.NewLine);
                
                // Ask if they want to go again, default is yes
                Console.Write("Deal again? (Y/n) ");
                if (Console.ReadLine().ToLower() == "n") break;
            }
        }

        static double Round(double x, int places = 0)
        {
            double offset = x < 0 ? Math.Pow(10, -places) : 0;
            double answer = Math.Round(x, places, MidpointRounding.AwayFromZero);
            return x == answer ? answer : answer + offset;
        }
    }
}
