using Core.Card.Deck;

namespace Cards.SlayTheSpire.Deck
{
    public class SlayTheSpireDeckFactory : AbstractDeckFactory
    {
        public override AbstractDeck CreateInstance()
        {
            return new SlayTheSpireDeck();
        }
    }
}