using System;
using System.Collections.Generic;
using Core;
using Core.Card;
using Core.Card.Deck;

namespace Game.Entities.Player
{
    public partial class PlayerController : ICardOwner
    {
        private AbstractDeck deck;
        private readonly HashSet<CardController> cards = new();
        public event Action<CardController> OnAddCard;
        public event Action<CardController> OnDiscard;

        internal void InitDeck(AbstractDeck deck)
        {
            this.deck = deck;
        }

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

        public IEnumerable<CardController> GetCards()
        {
            return cards;
        }

        private void Draw(int num)
        {
            var cardControllers = new List<CardController>();
            for (int i = 0; i < num; i++)
            {
                cardControllers.Add(new(deck.Draw()));
            }

            AddCard(cardControllers);
        }
    }
}