using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private List<Card> _pack;

        // Don't allow public pack to be changed
        public List<Card> pack
        {
            get { return _pack; }
            set {  }
        }

        public Pack()
        {
            _pack = new List<Card>();
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
                _pack = shuffled; // Overwrite pack
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
                _pack = shuffled; // Overwrite pack
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
            } else if (amount == 0)
            {
                throw new ArgumentOutOfRangeException("cannot deal zero cards");
            } else if (amount > pack.Count)
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
