using System.Collections.Generic;

namespace Core.Cards.CardFactory
{
    public interface ICardFactory
    {
        IEnumerable<AbstractCard> CreateCards();
    }
}