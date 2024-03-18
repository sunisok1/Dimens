﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
using Core.Action;
using Core.Cards;
using Core.Cards.CardFactory;
using UnityEngine;

namespace Core.Entities.Player
{
    public partial class Player : Entity, IUser
    {
        #region Events

        public event EventHandler<CardsDrawnEventArgs> CardsDrawn;
        public event EventHandler<CardsDiscardedEventArgs> CardsDiscarded;
        public event EventHandler<CardsPlayedEventArgs> CardsPlayed;

        #endregion

        private readonly Deck deck = new(new RedFactory());
        private List<AbstractCard> handCards { get; } = new();

        public List<AbstractCard> HandCards => new(handCards);

        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public Vector3Int Position { get; private set; }

        public Player(string name, int health, int maxHealth, Vector3Int position) : base(name)
        {
            MaxHealth = maxHealth;
            Position = position;
            Health = health > maxHealth ? maxHealth : health;
        }

        #region Actions

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth; // 确保治疗后生命值不会超过最大值
            }
        }

        

        public void DrawCards(int num = 1)
        {
            var cards = deck.Draw(num);
            handCards.AddRange(cards);
            CardsDrawn?.Invoke(this, new CardsDrawnEventArgs(cards));
        }

        public void DiscardCards(List<AbstractCard> cards)
        {
            handCards.RemoveAll(cards.ToHashSet().Contains);
            CardsDiscarded?.Invoke(this, new CardsDiscardedEventArgs(cards));
        }

        public void PlayCard(AbstractCard card, ITarget target)
        {
            handCards.Remove(card);
            card.Use(this, target);
            CardsPlayed?.Invoke(this, new CardsPlayedEventArgs(card, target));
        }

        #endregion

        public IEnumerator Play()
        {
            yield return new WaitWhile(() => true);
        }

        public void EndTurn()
        {
        }

        public void MoveTo(Vector3Int target)
        {
            EventSystem.InvokeEvent(this, new PlayerMoveEventArgs(Position, target));
            Position = target;
        }
    }
}