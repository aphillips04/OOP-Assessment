using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing.TestAll();

            Pack pack = new Pack();
            pack.shuffleCardPack(2);
            List<Card> cards = pack.dealCard(6);
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}
