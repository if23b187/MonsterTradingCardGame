namespace MonsterTradingCardGame.Game
{
    internal abstract class Card
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        protected Card(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public abstract string GetCardType();
    }
}
