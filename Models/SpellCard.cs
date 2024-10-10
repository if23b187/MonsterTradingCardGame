namespace MonsterTradingCardGame.Game
{
    internal class SpellCard : Card
    {
        public string SpellElementType { get; set; }

        public SpellCard(string name, int damage, string spellElementType)
            : base(name, damage)
        {
            SpellElementType = spellElementType;
        }

        public override string GetCardType()
        {
            return "Spell";
        }


    }
}
