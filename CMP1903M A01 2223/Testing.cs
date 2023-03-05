using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        public static void CreateCard()
        {
            int[][] cards =
            {
                new int[2] { 1, 1 }, // Lower valid
                new int[2] { 13, 4 }, // Upper valid
                new int[2] { 0, 1 }, // Valid too low
                new int[2] { 1, 0 }, // Suit too low
                new int[2] { 0, 0 }, // Both too low
                new int[2] { 14, 4 }, // Value too high
                new int[2] { 13, 5 }, // Suit too high
                new int[2] { 14, 5 }, // Both too high
            };
            foreach (int[] card in cards)
            {
                try
                {
                    new Card(card[0], card[1]);
                    if (card[0] == 0 || card[0] == 14)
                    {
                        throw new FailedTestException("invalid card value allowed");
                    } else if (card[1] == 0 || card[1] == 5)
                    {
                        throw new FailedTestException("invalid card suit allowed");
                    }
                } catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"ArgumentOutOfRangeException: {e.ParamName}");
                }
            }
        }
        public static void CreatePack()
        {
            Pack pack = new Pack();
        }

        public static void ShufflePack()
        {
            Pack pack = new Pack();
            List<Card> before;

            // Even pack size
            for (int i = 1; i <= 3;  i++)
            {
                before = pack.pack;
                pack.shuffleCardPack(i);
                if (pack.pack != before && i != 3)
                {
                    continue;
                }
                else if (i == 3 && pack.pack == before)
                {
                    continue;
                }
                throw new FailedTestException($"even pack is the same after being shuffled. shuffle method: {i}");
            }

            // Odd pack size
            pack.dealCard(7);
            for (int i = 1; i <= 3; i++)
            {
                before = pack.pack;
                pack.shuffleCardPack(i);
                if (pack.pack != before && i != 3)
                {
                    continue;
                }
                else if (i == 3 && pack.pack == before)
                {
                    continue;
                }
                throw new FailedTestException($"odd pack is the same after being shuffled. shuffle method: {i}");
            }

            try
            {
                pack.shuffleCardPack(4);
                throw new FailedTestException("invalid shuffle allowed");
            } catch (InvalidOperationException e)
            {
                Console.WriteLine($"InvalidOperationException: '{e.Message}'");
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
            int[] amounts = { 1, 2, 5, 10, 26, 52, -5, 0, 60 };
            foreach (int amount in amounts)
            {
                pack = new Pack();
                try
                {
                    cards = pack.dealCard(amount);
                    if (amount == -5)
                    {
                        throw new FailedTestException("negative amount of cards dealt");
                    } else if (amount == 0)
                    {
                        throw new FailedTestException("zero cards dealt");
                    }
                    else if (amount == 60)
                    {
                        throw new FailedTestException("more dealt than in the pack");
                    } else if (cards.Count == 0)
                    {
                        throw new FailedTestException("no cards dealt");
                    } else if (cards.Count != amount)
                    {
                        throw new FailedTestException("incorrect amount of cards dealt");
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
                    Console.WriteLine($"{amount} cards dealt successfully");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"ArgumentOutOfRangeException: '{e.ParamName}'");
                }
            }
        }

        public static void TestAll()
        {
            // Do tests
            CreateCard();
            CreatePack();
            ShufflePack();
            DealCardNoAmount();
            DealCardAmount();

            // Output success
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All tests passed!");
            Console.ForegroundColor = previous;
        }
    }
}
