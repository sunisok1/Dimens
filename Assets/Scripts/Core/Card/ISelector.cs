using System;
using System.Collections;

namespace Core.Card
{
    public interface ISelector
    {
        Func<AbstractCard, bool> Filter { get; set; }

        void Select(CardController card);
        void Unselect(CardController card);
        IEnumerator SelectTarget(Action<ITarget> returnValue);
    }
}