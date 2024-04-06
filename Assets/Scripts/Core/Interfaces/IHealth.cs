using System;

namespace Core
{
    public interface IHealth
    {
        event Action<int, int> OnHealthChange;
        int MaxHealth { get; }
        int Health { get; }
        void TakeDamage(DamageInfo damage);
        void Heal(int amount);
        void Die();
    }
}