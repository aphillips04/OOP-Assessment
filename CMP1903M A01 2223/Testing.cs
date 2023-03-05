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
            Pack pack = new Pack();
            for (int i = 1; i <= 3;  i++)
            {
                Console.WriteLine(pack.shuffleCardPack(i).ToString());
            }
            try
            {
                pack.shuffleCardPack(4);
                throw new FailedTestException("invalid shuffle allowed");
            } catch (InvalidOperationException e)
            {
                Console.WriteLine("InvalidOperationException: '" + e.Message + "'");
            }
        }

        public static void DealCardNoAmount()
        {
            // No amount specified
            Pack pack = new Pack();
            Card dealtCard = pack.dealCard();
            if (dealtCard == null)
            {
                throw new FailedTestException("no card dealt");
            }
            else if (pack.pack.Contains(dealtCard))
            {
                throw new FailedTestException("dealt card not removed from pack");
            }
            Console.WriteLine("Card dealt successfully");
        }
        
        public static void DealCardAmount()
        {
            Pack pack;
            List<Card> cards;
            int[] amounts = { 1, 2, 5, 10, 26, 52, 60 };
            foreach (int amount in amounts)
            {
                pack = new Pack();
                try
                {
                    cards = pack.dealCard(amount);
                    if (amount == 60)
                    {
                        throw new FailedTestException("more dealt than in the pack");
                    } else if (cards.Count == 0)
                    {
                        throw new FailedTestException("no cards dealt");
                    }
                    foreach (Card card in cards)
                    {
                        if (card == null)
                        {
                            throw new FailedTestException("null card dealt");
                        }
                        else if (pack.pack.Contains(card))
                        {
                            throw new FailedTestException("dealt card not removed from pack");
                        }
                    }
                    Console.WriteLine(amount.ToString() + " cards dealt successfully");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("ArgumentOutOfRangeException: '" + e.Message + "'");
                }
            }
        }
    }
}
