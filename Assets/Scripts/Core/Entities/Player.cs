using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Player : Entity
    {
        private List<Card> cards;
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public Player(string name, int health, int maxHealth) : base(name)
        {
            MaxHealth = maxHealth;
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
    }
}