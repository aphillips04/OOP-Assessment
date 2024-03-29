﻿using System;
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
        /// Method <c>CreateCard</c> tests card creation.
        /// </summary>
        /// <exception cref="FailedTestException"></exception>
        public static void CreateCard() 
        {
            // Define card details
            int[][] cards =
            {
                new int[2] { 1, 1 }, // Lower valid
                new int[2] { 13, 4 }, // Upper valid
                new int[2] { 0, 1 }, // Value too low
                new int[2] { 1, 0 }, // Suit too low
                new int[2] { 0, 0 }, // Both too low
                new int[2] { 14, 4 }, // Value too high
                new int[2] { 13, 5 }, // Suit too high
                new int[2] { 14, 5 }, // Both too high
            };
            foreach (int[] card in cards)
            {
                // Try to create the Card object, catch expected exceptions
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
        
        /// <summary>
        /// Method <c>CreatePack</c> tests pack creation.
        /// </summary>
        public static void CreatePack()
        {
            Pack pack = new Pack();
        }

        /// <summary>
        /// Method <c>ShufflePack</c> test shuffling the pack.
        /// </summary>
        /// <exception cref="FailedTestException"></exception>
        public static void ShufflePack()
        {
            Pack pack = new Pack();
            List<Card> before;

            // Even pack size
            for (int i = 1; i <= 3;  i++)
            {
                before = pack.pack; // Save for checking
                if (pack.shuffleCardPack(i) != true)
                {
                    throw new FailedTestException("incorrect return value");
                }
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
                before = pack.pack; // Save for checking
                if (pack.shuffleCardPack(i) != true)
                {
                    throw new FailedTestException("incorrect return value");
                }
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
            
            // Try an invalid shuffle number, catch expected exception
            try
            {
                pack.shuffleCardPack(4);
                throw new FailedTestException("invalid shuffle allowed");
            } catch (InvalidOperationException e)
            {
                Console.WriteLine($"InvalidOperationException: '{e.Message}'");
            }
        }

        /// <summary>
        /// Method <c>DealCardNoAmount</c> tests dealing cards without passing an amount.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FailedTestException"></exception>
        public static void DealCardNoAmount()
        {
            // No amount specified
            Pack pack = new Pack();
            Card dealtCard = pack.dealCard();
            if (dealtCard.GetType() != typeof(Card))
            {
                throw new Exception("incorrect return type");
            }
            else if (dealtCard == null)
            {
                throw new FailedTestException("no card dealt");
            }
            else if (pack.pack.Contains(dealtCard))
            {
                throw new FailedTestException("dealt card not removed from pack");
            }
            Console.WriteLine("Card dealt successfully");
        }

        /// <summary>
        /// Method <c>DealCardAmount</c> tests dealing cards when passing an amount.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FailedTestException"></exception>
        public static void DealCardAmount()
        {
            Pack pack;
            List<Card> cards;
            int[] amounts = 
            {
                1, 2, 5, 10, 26, 52, // Valid amounts
                -5, 0, 60 // Invalid amounts
            };
            foreach (int amount in amounts)
            {
                pack = new Pack(); // Create a new pack each time to allow larger test values
                // Try deal the amount of cards, catch expected exceptions
                try
                {
                    cards = pack.dealCard(amount);
                    if (cards.GetType() != typeof(List<Card>))
                    {
                        throw new Exception("incorrect return type");
                    }
                    else if (amount == -5)
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

        /// <summary>
        /// Method <c>TestAll</c> runs all tests and outputs a success message.
        /// </summary>
        public static void TestAll()
        {
            // Do tests
            CreateCard();
            CreatePack();
            ShufflePack();
            DealCardNoAmount();
            DealCardAmount();

            // Output success
            ConsoleColor previous = Console.ForegroundColor; // Save so we can reset the colour afterwards
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All tests passed!");
            Console.ForegroundColor = previous;
        }
    }
}
