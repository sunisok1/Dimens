using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Entities
{
    public partial class Player : Entity
    {
        #region Events

        public event EventHandler<CardsDrawnEventArgs> CardsDrawn;
        public event EventHandler<CardsDiscardedEventArgs> CardsDiscarded;
        public event EventHandler<CardsPlayedEventArgs> CardsPlayed;

        #endregion

        private readonly Deck deck = new();
        private List<Card> handCards { get; } = new();

        public List<Card> HandCards => new(handCards);

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

        public void Equip(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void DrawCards(int num = 1)
        {
            var cards = deck.Draw(num);
            handCards.AddRange(cards);
            CardsDrawn?.Invoke(this, new CardsDrawnEventArgs(cards));
        }

        public void DiscardCards(List<Card> cards)
        {
            handCards.RemoveAll(cards.ToHashSet().Contains);
            CardsDiscarded?.Invoke(this, new CardsDiscardedEventArgs(cards));
        }
        
        public void PlayCards(List<Card> cards, Player targetPlayer)
        {
            handCards.RemoveAll(cards.ToHashSet().Contains);
            CardsPlayed?.Invoke(this, new CardsPlayedEventArgs(cards, targetPlayer));
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