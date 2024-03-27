namespace Classes.Entities
{
    public interface IHealthController
    {
        void TakeDamage(DamageInfo damage);
        void Heal(int amount);
        void Die();
    }
}