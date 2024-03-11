using System;
using System.Collections;
using System.Collections.Generic;
using Core.Cards;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Entities
{
    public class Deck
    {
        private readonly List<Card> cards = new();

        public Deck()
        {
            for (int i = 0; i < 5; i++)
            {
                cards.Add(new AttackCard("strike", "strike", 1, null));
                cards.Add(new EffectCard("strike", "strike", 1, null));
                cards.Add(new EquipmentCard("strike", "strike", new()));
            }

            Shuffle();
        }

        public void Shuffle()
        {
            for (var i = 0; i < cards.Count; i++)
            {
                var x = Random.Range(i, cards.Count);
                (cards[i], cards[x]) = (cards[x], cards[i]);
            }
        }

        public IEnumerable<Card> Draw(int num)
        {
            List<Card> list = new();

            int actualNum = Math.Min(num, cards.Count);

            for (int i = 0; i < actualNum; i++)
            {
                Card card = cards[^1];
                cards.RemoveAt(cards.Count - 1);
                list.Add(card);
            }

            return list;
        }
    }

    public class Player : Entity
    {
        private readonly Deck deck = new();
        private readonly List<Card> handCards = new();
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public Vector3Int Position { get; private set; }

        public Player(string name, int health, int maxHealth, Vector3Int position) : base(name)
        {
            MaxHealth = maxHealth;
            Position = position;
            Health = health > maxHealth ? maxHealth : health;
        }

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

        public void Draw(int num = 1)
        {
            handCards.AddRange(deck.Draw(num));
        }

        public IEnumerator Play()
        {
            yield return new WaitForSeconds(2f);
        }

        public void EndTurn()
        {
        }

        public void MoveTo(Vector3Int target)
        {
            EventSystem.InvokeEvent(this, new PlayerMoveArgs(Position, target));
            Position = target;
        }
    }

    public class PlayerMoveArgs : EventArgs
    {
        public Vector3Int origin { get; }
        public Vector3Int target { get; }

        public PlayerMoveArgs(Vector3Int origin, Vector3Int target)
        {
            this.origin = origin;
            this.target = target;
        }
    }
}