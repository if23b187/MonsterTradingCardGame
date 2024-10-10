namespace MonsterTradingCardGame.Game
{
    internal class Deck
    {
        private List<Card> deck;

        public Deck(List<Card> deck)
        {
            this.deck = deck;
        }

        public List<Card> Cards { get; private set; } = new List<Card>();

        public void AddCard(Card card)
        {
            if (Cards.Count < 4)
            {
                Cards.Add(card);
            }
        }

        public Card GetRandomCard()
        {
            var random = new Random();
            int index = random.Next(Cards.Count);
            return Cards[index];
        }

        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
        }
    }
}
