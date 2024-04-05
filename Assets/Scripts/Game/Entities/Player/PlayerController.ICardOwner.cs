using System;
using System.Collections.Generic;
using Core;
using Core.Card;

namespace Game.Entities.Player
{
    public partial class PlayerController : ICardOwner
    {
        public event Action<CardController> OnAddCard;
        public event Action<CardController> OnDiscard;

        public void AddCard(IEnumerable<CardController> addedCards)
        {
            foreach (var card in addedCards)
            {
                model.cards.Add(card);
                OnAddCard?.Invoke(card);
            }
        }

        public void Discard(IEnumerable<CardController> discards)
        {
            foreach (var card in discards)
            {
                model.cards.Remove(card);
                OnDiscard?.Invoke(card);
            }
        }

        public void UseCard(CardController card, ITarget target)
        {
            model.cards.Remove(card);
            Unselect(card);
            card.Use(this, target);
            OnUseCard?.Invoke(card);
        }

        public IEnumerable<CardController> GetCards()
        {
            return model.cards;
        }
    }
}