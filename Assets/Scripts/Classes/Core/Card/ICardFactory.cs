using System.Collections.Generic;

namespace Core.Card
{
    public interface ICardFactory
    {
        IEnumerable<AbstractCard> CreateCards();
    }
}