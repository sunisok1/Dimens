using System;
using System.Collections.Generic;
using Common;
using Core.Action;
using Core.Cards;
using Core.Entities.Player;
using Core.System.Input;
using Core.System.Turn;
using UI.Card;
using UnityEngine;

namespace UI.Game
{
    public class CardPanel : MonoBehaviour
    {
        public readonly InputSystem<AbstractCard> inputSystem = new();
        [SerializeField] private RectTransform content;

        private readonly Dictionary<AbstractCard, CardWrapper> cardUIDictionary = new();
        private Player currentPlayer;

        private void Start()
        {
            EventSystem.Subscribe<PlayerChangedEventArgs>(OnPlayerChanged);
        }


        private void OnPlayerChanged(object sender, PlayerChangedEventArgs e)
        {
            List<AbstractCard> handCards = e.CurrentPlayer.HandCards;
            UnsubscribeEvents(e.PreviousPlayer);
            SubscribeEvents(e.CurrentPlayer);
            UpdateCards(handCards);
        }

        private void UpdateCards(List<AbstractCard> handCards)
        {
            // 销毁并清除所有当前的卡牌UI
            foreach (var cardObject in cardUIDictionary.Values)
            {
                Destroy(cardObject.gameObject);
            }

            cardUIDictionary.Clear();

            // 为手牌中的每张卡生成UI
            foreach (AbstractCard card in handCards)
            {
                var cardUI = ObjectManager.Create<CardWrapper>(content, card);
                cardUIDictionary.Add(card, cardUI);
            }
        }

        private void SubscribeEvents(Player player)
        {
            if (player == null) return;
            currentPlayer = player;
            player.OnCardDraw += OnCardDraw;
            player.OnDiscard += OnDiscard;
            player.OnPlayCard += OnPlayCard;
        }

        private void UnsubscribeEvents(Player player)
        {
            if (player == null) return;
            if (player != currentPlayer) return;
            player.OnCardDraw -= OnCardDraw;
            player.OnDiscard -= OnDiscard;
            player.OnPlayCard -= OnPlayCard;
        }

        private void OnCardDraw(object sender, CardDrawArgs e)
        {
            var card = e.card;
            if (!cardUIDictionary.ContainsKey(card))
            {
                CardWrapper cardObject;
                switch (card)
                {
                    case SlayTheSpireCard slayTheSpireCard:
                        cardObject = ObjectManager.Create<CardWrapper>(content, slayTheSpireCard);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(card));
                }

                cardUIDictionary.Add(card, cardObject);
            }
        }


        private void OnDiscard(object sender, DiscardArgs e)
        {
            var card = e.card;
            if (cardUIDictionary.TryGetValue(card, out CardWrapper cardUI))
            {
                Destroy(cardUI.gameObject);
                cardUIDictionary.Remove(card);
            }
        }

        private void OnPlayCard(object sender, PlayCardArgs e)
        {
            if (cardUIDictionary.TryGetValue(e.card, out CardWrapper cardUI))
            {
                Destroy(cardUI.gameObject);
                cardUIDictionary.Remove(e.card);
            }
        }


        private void OnDestroy()
        {
            EventSystem.Unsubscribe<PlayerChangedEventArgs>(OnPlayerChanged);

            UnsubscribeEvents(currentPlayer); // 使用currentPlayer确保正确地取消订阅  }
        }
    }
}