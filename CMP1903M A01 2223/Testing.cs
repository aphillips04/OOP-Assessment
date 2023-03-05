using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class FailedTestException : Exception
    {
        public FailedTestException()
        {
        }
        
        public FailedTestException(string message) : base(message)
        {
        }

        public FailedTestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    class Testing
    {
        public static void CreatePack()
        {
            Pack pack = new Pack();
        }

        public static void ShufflePack()
        {
            Pack deck = new Pack();
            for (int i = 1; i <= 3;  i++)
            {
                Console.WriteLine(deck.shuffleCardPack(i).ToString());
            }
            try
            {
                deck.shuffleCardPack(4);
                throw new FailedTestException("invalid shuffle allowed");
            } catch (InvalidOperationException e)
            {
                Console.WriteLine("InvalidOperationException: '" + e.Message + "'");
            }
        }
    }
}
