using System;
using System.Collections.Generic;
using Core.Card;

namespace Core
{
    public interface ICardOwner
    {
        public event Action<CardController> OnAddCard ;
        public event Action<CardController> OnDiscard ;
        void AddCard(IEnumerable<CardController> addedCards);
        void Discard(IEnumerable<CardController> discards);
        IEnumerable<CardController> GetCards();
    }
}