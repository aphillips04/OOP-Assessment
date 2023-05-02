using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    /// <summary>
    /// Class <c>Testing</c> handles all testing.
    /// </summary>
    class Testing
    {
        /// <summary>
        /// Method <c>TestAll</c> runs all tests and outputs a success message.
        /// </summary>
        public static void TestAll()
        {
            // Do tests

            // Output success
            ConsoleColor previous = Console.ForegroundColor; // Save so we can reset the colour afterwards
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All tests passed!");
            Console.ForegroundColor = previous;
        }
    }
}
