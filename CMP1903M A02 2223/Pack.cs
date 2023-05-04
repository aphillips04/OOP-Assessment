using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
{
    /// <summary>
    /// Class <c>Pack</c> handles a pack of cards and actions performed on it.
    /// </summary>
    class Pack
    {
        // Don't alloaw public pack to be changed
        public List<Card> pack { get; private set; }

        /// <summary>
        /// Method <c>Pack</c> constructs the pack in an unshuffled order.
        /// </summary>
        public Pack()
        {
            pack = new List<Card>();
            int v, s;
            // Create pack in to be pulled in ascending order, sorted by suit
            for (s = 1; s <= 4; s++)
            {
                for (v = 1; v <= 13; v++)
                {
                    pack.Add(new Card(v, s));
                }
            }
        }

        /// <summary>
        /// Method <c>shuffleCardPack</c> performs different shuffles based on which type is passed.
        /// </summary>
        /// <param name="typeOfShuffle"></param>
        /// <returns>Boolean based on wheather the shuffle was a success or not</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool shuffleCardPack(int typeOfShuffle)
        {
            if (typeOfShuffle == 1)
            {
                // Do Fisher-Yates shuffle
                List<Card> shuffled = new List<Card>(pack); // Copy pack to avoid issues
                int i, j;
                Card tmp;
                Random rng = new Random();
                for (i = 0; i < shuffled.Count - 1; i++)
                {
                    // Random index greater than or equal to i
                    j = rng.Next(i, shuffled.Count);
                    // Swap cards at index i and index j
                    tmp = shuffled[i];
                    shuffled[i] = shuffled[j];
                    shuffled[j] = tmp;
                }
                pack = shuffled; // Overwrite pack
                return true;
            }
            else if (typeOfShuffle == 2)
            {
                // Do Riffle shuffle
                List<Card> left = pack.GetRange(0, pack.Count / 2);
                int rightCount = pack.Count - left.Count; // Don't forget the last card when odd sized pack
                List<Card> right = pack.GetRange(pack.Count / 2, rightCount);

                List<Card> shuffled = new List<Card>();
                int i;
                for (i = 0; i < left.Count; i++)
                {
                    shuffled.Add(right[i]);
                    shuffled.Add(left[i]);
                }
                // If there is a missing card then add it
                if (shuffled.Count != pack.Count)
                {
                    shuffled.Add(right[i]); // Don't add 1 as i++ adds after returning the value
                }
                pack = shuffled; // Overwrite pack
                return true;
            }
            else if (typeOfShuffle == 3)
            {
                // Do no shuffle
                return true;
            }
            else
            {
                throw new InvalidOperationException("invalid shuffle type");
            }
        }

        /// <summary>
        /// Method <c>dealCard</c> deals a single card.
        /// </summary>
        /// <returns>The card at the top (index 0) of the pack</returns>
        /// <exception cref="EmptyPackException"></exception>
        public Card dealCard()
        {
            //Deals one card
            if (pack.Count == 0)
            {
                throw new EmptyPackException("pack is empty");
            }
            // Get first index and remove it
            Card card = pack[0];
            pack.RemoveAt(0);
            return card;

        }

        /// <summary>
        /// Method <c>dealCard</c> deals the amount of cards passed.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>A list of cards from the top (index 0) to the amount</returns>
        /// <exception cref="EmptyPackException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            if (pack.Count == 0)
            {
                throw new EmptyPackException("pack is empty");
            }
            else if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("cannot deal negative amount of cards");
            }
            else if (amount == 0)
            {
                throw new ArgumentOutOfRangeException("cannot deal zero cards");
            }
            else if (amount > pack.Count)
            {
                throw new ArgumentOutOfRangeException("cannot deal more cards than in the pack");
            }
            // Get the range and remove it
            List<Card> cards = pack.GetRange(0, amount);
            pack.RemoveRange(0, amount);
            return cards;
        }
    }
}
