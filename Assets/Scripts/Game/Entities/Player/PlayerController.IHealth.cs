using System;
using Core;
using UnityEngine;

namespace Game.Entities.Player
{
    public partial class Player : IHealth
    {
        public event Action<int, int> OnHealthChange;

        private int health;
        private int maxHealth;

        public int Health
        {
            get => health;
            set
            {
                health = Mathf.Min(value, MaxHealth);
                OnHealthChange?.Invoke(health, maxHealth);
                if (Health <= 0)
                    Die();
            }
        }

        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                maxHealth = value;
                OnHealthChange?.Invoke(health, maxHealth);
            }
        }

        public void SetHealth(int health, int maxHealth)
        {
            Health = health;
            MaxHealth = maxHealth;
        }

        public void TakeDamage(DamageInfo damage)
        {
            Health -= damage.num;
        }

        public void Heal(int amount)
        {
            Health += amount;
        }

        public void Die()
        {
        }
    }
}