using System;
using System.Collections.Generic;
using Core;
using Core.Card;
using Core.Entities;

namespace Game.Entities.Player
{
    public partial class Player : ICardOwner
    {
        public event Action<CardController> OnAddCard;
        public event Action<CardController> OnDiscard;

        public void AddCard(IEnumerable<CardController> addedCards)
        {
            foreach (var card in addedCards)
            {
                cards.Add(card);
                OnAddCard?.Invoke(card);
            }
        }

        public void Discard(IEnumerable<CardController> discards)
        {
            foreach (var card in discards)
            {
                cards.Remove(card);
                OnDiscard?.Invoke(card);
            }
        }

        public void Draw(int amount)
        {
            var cardControllers = new List<CardController>();
            for (var i = 0; i < amount; i++)
            {
                cardControllers.Add(new(Deck.Draw()));
            }

            AddCard(cardControllers);
        }

        public void UseCard(CardController card, AbstractEntity target)
        {
            cards.Remove(card);
            Unselect(card);
            card.Use(this, target);
            OnUseCard?.Invoke(card);
        }

        public IEnumerable<CardController> GetCards()
        {
            return cards;
        }
    }
}