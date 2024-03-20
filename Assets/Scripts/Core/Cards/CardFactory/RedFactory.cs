using System.Collections.Generic;
using Core.Cards.SlayTheSpire.Red;

namespace Core.Cards.CardFactory
{
    public class RedFactory : ICardFactory
    {
        public IEnumerable<AbstractCard> CreateCards()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new StrikeRed();
            }
        }
    }
}