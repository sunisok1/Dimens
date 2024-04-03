using System.Collections.Generic;
using Core;
using Core.Card;
using UnityEngine;

namespace Systems.TurnSystem
{
    internal class CardPanel : MonoBehaviour
    {
        [SerializeField] private Transform content;
        private ICardOwner currentCardOwner;
        private readonly HashSet<CardController> cardControllers = new();

        public ICardOwner CurrentCardOwner
        {
            set
            {
                UnSubscriptEvents(currentCardOwner);
                SubscriptEvents(value);

                currentCardOwner = value;

                ClearCardViews();
                CreateCardViews();

                return;

                void UnSubscriptEvents(ICardOwner cardOwner)
                {
                    if (cardOwner == null) return;
                    cardOwner.OnAddCard -= DisplayCard;
                    cardOwner.OnDiscard -= RemoveCard;
                }

                void SubscriptEvents(ICardOwner cardOwner)
                {
                    cardOwner.OnAddCard += DisplayCard;
                    cardOwner.OnDiscard += RemoveCard;
                }

                void ClearCardViews()
                {
                    foreach (CardController card in cardControllers)
                    {
                        card.DestroyView();
                    }

                    cardControllers.Clear();
                }

                void CreateCardViews()
                {
                    var cards = currentCardOwner.GetCards();
                    foreach (var card in cards)
                    {
                        DisplayCard(card);
                    }
                }
            }
        }


        private void DisplayCard(CardController card)
        {
            cardControllers.Add(card);
            card.CreateView(content);
        }

        private void RemoveCard(CardController card)
        {
            if (cardControllers.Remove(card))
                card.DestroyView();
        }

        private void OnDestroy()
        {
            if (currentCardOwner != null)
            {
                currentCardOwner.OnAddCard -= DisplayCard;
                currentCardOwner.OnDiscard -= RemoveCard;
            }
        }
    }
}