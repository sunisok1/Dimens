using System.Collections.Generic;
using Classes;

namespace Core.Cards
{
    public interface ICardFactory
    {
        IEnumerable<AbstractCard> CreateCards();
    }
}