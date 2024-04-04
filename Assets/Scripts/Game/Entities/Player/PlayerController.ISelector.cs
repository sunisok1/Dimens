using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Card;
using UnityEngine;

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

        private IEnumerator SelectCard()
        {
            yield return new WaitWhile(() => selectedCard == null);
        }

        public IEnumerator SelectTarget(Action<ITarget> callback)
        {
            yield break;
        }
    }
}