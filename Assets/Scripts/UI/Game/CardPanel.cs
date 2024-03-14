using System;
using System.Collections.Generic;
using Core;
using Core.Entities;
using Core.System;
using UnityEngine;

namespace UI.Game
{
    public class CardPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform content;

        private readonly Dictionary<Card, CardObject> cardUIDictionary = new();
        private Player currentPlayer;

        private void Start()
        {
            EventSystem.Subscribe<PlayerChangedEventArgs>(OnPlayerChanged);
        }


        private void OnPlayerChanged(object sender, PlayerChangedEventArgs e)
        {
            List<Card> handCards = e.CurrentPlayer.HandCards;
            UnsubscribeEvents(e.PreviousPlayer);
            SubscribeEvents(e.CurrentPlayer);
            UpdateCards(handCards);
        }

        private void UpdateCards(List<Card> handCards)
        {
            // 销毁并清除所有当前的卡牌UI
            foreach (var cardObject in cardUIDictionary.Values)
            {
                Destroy(cardObject.gameObject);
            }

            cardUIDictionary.Clear();

            // 为手牌中的每张卡生成UI
            foreach (Card card in handCards)
            {
                var cardUI = ObjectManager.Create<CardObject>(content);
                cardUI.SetCardInfo(card);
                cardUIDictionary.Add(card, cardUI);
            }
        }

        private void SubscribeEvents(Player player)
        {
            if (player == null) return;
            currentPlayer = player;
            player.CardsDrawn += OnCardsDrawn;
            player.CardsDiscarded += OnCardsDiscarded;
            player.CardsPlayed += OnCardsPlayed;
        }

        private void UnsubscribeEvents(Player player)
        {
            if (player == null) return;
            if (player != currentPlayer) return;
            player.CardsDrawn -= OnCardsDrawn;
            player.CardsDiscarded -= OnCardsDiscarded;
            player.CardsPlayed -= OnCardsPlayed;
        }

        private void OnCardsDrawn(object sender, CardsDrawnEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                if (!cardUIDictionary.ContainsKey(card))
                {
                    var cardObject = ObjectManager.Create<CardObject>(content);
                    cardObject.SetCardInfo(card);
                    cardUIDictionary.Add(card, cardObject);
                }
            }
        }


        private void OnCardsDiscarded(object sender, CardsDiscardedEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                if (cardUIDictionary.TryGetValue(card, out CardObject cardUI))
                {
                    Destroy(cardUI.gameObject);
                    cardUIDictionary.Remove(card);
                }
            }
        }

        private void OnCardsPlayed(object sender, CardsPlayedEventArgs e)
        {
            foreach (var card in e.Cards)
            {
                if (cardUIDictionary.TryGetValue(card, out CardObject cardUI))
                {
                    Destroy(cardUI.gameObject);
                    cardUIDictionary.Remove(card);
                }
            }
        }


        private void OnDestroy()
        {
            EventSystem.Unsubscribe<PlayerChangedEventArgs>(OnPlayerChanged);

            UnsubscribeEvents(currentPlayer); // 使用currentPlayer确保正确地取消订阅  }
        }
    }
}