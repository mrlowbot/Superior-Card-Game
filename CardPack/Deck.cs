using System.Collections.Generic;

namespace Card_Game.CardPack
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public void InitializeDeck()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    Cards.Add(new Card((Suit)suit, rank));
                }
            }
        }
    }
}
