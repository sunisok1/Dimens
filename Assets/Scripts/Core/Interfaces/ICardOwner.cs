using System;
using System.Collections.Generic;
using Core.Card;

namespace Core
{
    public interface ICardOwner
    {
        event Action<CardController> OnUseCard;
        event Action<CardController> OnAddCard;
        event Action<CardController> OnDiscard;
        void AddCard(IEnumerable<CardController> addedCards);
        void Discard(IEnumerable<CardController> discards);
        IEnumerable<CardController> GetCards();
        void UseCard(CardController card, ITarget target);
    }
}