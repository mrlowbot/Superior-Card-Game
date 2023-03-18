using Card_Game.CardPack;

namespace CardGame
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Deck deck = new Deck();
            CardOperations operations = new CardOperations();
            API api = new API();
            FactAPI factApi = new FactAPI();
            List<Card> playerCards = new List<Card>();
            List<Card> opponentCards = new List<Card>();
            NasaAPI nasaApi = new NasaAPI();

            deck.InitializeDeck();
            await operations.ShuffleAsync(deck);
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Draw a card for the player");
                Console.WriteLine("2. Draw a card for the opponent");
                Console.WriteLine("3. Shuffle the deck");
                Console.WriteLine("4. Count cards in the deck");
                Console.WriteLine("5. Simulate player turn");
                Console.WriteLine("6. Show player and opponent cards");
                Console.WriteLine("7. Get a random joke");
                Console.WriteLine("8. Get a random fact");
                Console.WriteLine("9. Get Astronomy Picture of the Day");
                Console.WriteLine("10. Exit\n");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Console.Clear();
                                Card playerCard = await operations.DrawAsync(deck);
                                playerCards.Add(playerCard);
                                Console.WriteLine("Player drew: " + playerCard.ToString() + "\n");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 2:
                            try
                            {
                                Console.Clear();
                                Card opponentCard = await operations.DrawAsync(deck);
                                opponentCards.Add(opponentCard);
                                Console.WriteLine("Opponent drew: " + opponentCard.ToString() + "\n");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 3:
                            Console.Clear();
                            await operations.ShuffleAsync(deck);
                            Console.WriteLine("Deck shuffled.\n");
                            break;

                        case 4:
                            Console.Clear();
                            int cardCount = operations.Count(deck);
                            Console.WriteLine("Number of cards left in the deck: " + cardCount + "\n");
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("Simulating player turn...\n");
                            await operations.SimulatePlayerTurnAsync(3000);
                            Console.WriteLine("Player turn finished.\n");
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine("Player cards:");
                            foreach (Card card in playerCards)
                            {
                                Console.WriteLine(card.ToString());
                            }
                            Console.WriteLine("\nOpponent cards:");
                            foreach (Card card in opponentCards)
                            {
                                Console.WriteLine(card.ToString());
                            }
                            Console.WriteLine();
                            break;

                        case 7:
                            Console.Clear();
                            string joke = await api.GetRandomJokeAsync();
                            Console.WriteLine("Random joke: " + joke + "\n");
                            break;

                        case 8:
                            Console.Clear();
                            string fact = await factApi.GetRandomFactAsync();
                            Console.WriteLine("Random fact: " + fact + "\n");
                            break;

                        case 9:
                            Console.Clear();
                            string apod = await nasaApi.GetAstronomyPictureOfTheDayAsync();
                            Console.WriteLine("Astronomy Picture of the Day:\n" + apod + "\n");
                            break;

                        case 10:
                            Console.Clear();
                            Console.WriteLine("Exiting...\n");
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid option. Please try again.\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please try again.\n");
                }
            }
        }
    }
}
