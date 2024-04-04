using System;
using System.Collections.Generic;

namespace Core.Card
{
    public interface ISelector
    {
        Func<AbstractCard, bool> Filter { get; set; }

        void Select(CardController card);
        void Unselect(CardController card);
    }
}