using System.Collections.Generic;
using Core.Cards;

public interface ICardFactory
{
    IEnumerable<AbstractCard> CreateCards();
}