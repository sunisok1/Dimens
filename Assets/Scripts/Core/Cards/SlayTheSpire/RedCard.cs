namespace Core.Cards.SlayTheSpire
{
    public abstract class RedCard : SlayTheSpireCard
    {
        protected RedCard(string cardID, string name, string portrait, int cost, string rawDescription, CardType type, CardRarity rarity, CardTarget target) : base(cardID,name,  portrait, cost, rawDescription, type, rarity, CardColor.Red, target)
        {
        }
    }
}