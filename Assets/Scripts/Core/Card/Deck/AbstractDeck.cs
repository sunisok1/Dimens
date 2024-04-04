using System.Collections.Generic;

namespace Core.Card.Deck
{
    public abstract class AbstractDeck
    {
        protected readonly List<AbstractCard> cardList = new();

        public AbstractCard Draw()
        {
            var card = cardList[^1];
            cardList.RemoveAt(cardList.Count - 1);
            return card;
        }
    }
}