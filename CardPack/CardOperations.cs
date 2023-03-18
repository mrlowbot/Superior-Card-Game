namespace Card_Game.CardPack
{
    public class CardOperations
    {
        private Random random = new Random();

        public async Task ShuffleAsync(Deck deck)
        {
            await Task.Run(() => Shuffle(deck));
        }

        private void Shuffle(Deck deck)
        {
            for (int i = deck.Cards.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);
                Card temp = deck.Cards[i];
                deck.Cards[i] = deck.Cards[randomIndex];
                deck.Cards[randomIndex] = temp;
            }
        }

        public async Task<Card> DrawAsync(Deck deck)
        {
            return await Task.Run(() => Draw(deck));
        }

        private Card Draw(Deck deck)
        {
            if (deck.Cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty.");
            }

            Card card = deck.Cards[0];
            deck.Cards.RemoveAt(0);
            return card;
        }

        public int Count(Deck deck)
        {
            return deck.Cards.Count;
        }

        public async Task SimulatePlayerTurnAsync(int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
        }
    }
}
