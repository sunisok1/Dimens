using System;
using System.Collections;
using Core.Entities;

namespace Core.Card
{
    public interface ISelector
    {
        Func<AbstractCard, bool> Filter { get; set; }

        void Select(CardController card);
        void Unselect(CardController card);
        IEnumerator SelectTarget(Action<AbstractEntity> returnValue);
    }
}