using System;
using System.Collections.Generic;
using Core.Card;

namespace Game.Entities.Player
{
    public partial class PlayerController : ISelector
    {
        private CardController selectedCard;

        public Func<AbstractCard, bool> Filter { get; set; }

        public void Select(CardController card)
        {
            selectedCard?.Unselect();
            selectedCard = card;
        }

        public void Unselect(CardController card)
        {
            selectedCard = null;
        }

        private void InitSelector(IEnumerable<CardController> cardControllers, Func<AbstractCard, bool> filter)
        {
            Filter = filter;
            foreach (CardController cardController in cardControllers)
            {
                cardController.Selector = this;
            }
        }
    }
}