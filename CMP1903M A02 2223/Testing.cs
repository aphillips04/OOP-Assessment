using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
{
    /// <summary>
    /// Class <c>Testing</c> handles all testing.
    /// </summary>
    class Testing
    {
        /// <summary>
        /// Method <c>EvenCount</c> tests passing an even (invalid) amount to the Tutor method
        /// </summary>
        /// <exception cref="FailedTestException"></exception>
        static void EvenCount()
        {
            try
            {
                Tutorial.Tutor(4);
                throw new FailedTestException("even amount allowed");
            } catch (InvalidElementCountException e)
            {
                Console.WriteLine($"InvalidElementCountException: {e.Message}");
            }
        }

        /// <summary>
        /// Method <c>GenerateExpression</c> tests the expression generation logic
        /// </summary>
        /// <exception cref="FailedTestException"></exception>
        static void GenerateExpression()
        {
            Pack pack = new Pack();
            List<Card> values = pack.dealCard(23); // No shuffle so will deal Ace through Nine of Spades every time
            string[] ops = new string[] { "+", "-", "*", "/" };
            string expr = "";
            for (int i = 0; i < values.Count; i++) expr += (i % 2 == 0) ? $"{values[i].Value} " : $"{ops[values[i].Suit - 1]} ";
            if (expr != "1 + 3 + 5 + 7 + 9 + 11 + 13 - 2 - 4 - 6 - 8 - 10 ") throw new FailedTestException("incorrect generation of expression");
        }

        /// <summary>
        /// Method <c>Round</c> tests rounding of integers, decimals and negatives to different numbers of places
        /// </summary>
        /// <exception cref="FailedTestException"></exception>
        static void Round()
        {
            double[][] values = 
            {
                new double[3] { 0, 0, 0 },
                new double[3] { 10, 0, 10 },
                new double[3] { -10, 0, -10 },
                new double[3] { 1.5, 0, 2 },
                new double[3] { 2.5, 0, 3 },
                new double[3] { -1.5, 0, -1 },
                new double[3] { -2.5, 0, -2 },
                new double[3] { 3.1456, 2, 3.15 },
                new double[3] { -3.1456, 2, -3.14 },
                new double[3] { 7.269853, 4, 7.2699 },
                new double[3] { -7.269853, 4, -7.2698 }
            };
            double toRound, answer, rounded;
            int places;
            foreach (double[] value in values)
            {
                toRound = value[0];
                places = (int)value[1];
                answer = value[2];
                rounded = Tutorial.Round(toRound, places);
                if (rounded != answer) throw new FailedTestException($"Round({toRound}, {places}) = {rounded} [{answer}]");
            }
        }

        /// <summary>
        /// Method <c>TestAll</c> runs all tests and outputs a success message.
        /// </summary>
        public static void TestAll()
        {
            // Do tests
            EvenCount();
            GenerateExpression();
            Round();

            // Output success
            ConsoleColor previous = Console.ForegroundColor; // Save so we can reset the colour afterwards
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All tests passed!");
            Console.ForegroundColor = previous;
        }
    }
}
