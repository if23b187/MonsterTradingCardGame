namespace MonsterTradingCardGame.Game
{
    internal class MonsterCard : Card
    {
        public string ElementType { get; set; }

        public MonsterCard(string name, int damage, string elementType)
            : base(name, damage)
        {
            ElementType = elementType;
        }

        public override string GetCardType()
        {
            return "Monster";
        }
    }
}
