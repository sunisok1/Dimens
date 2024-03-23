namespace Classes.Entities.Controller
{
    public interface IHealthController
    {
        void TakeDamage(DamageInfo damage);
        void Heal(int amount);
        void Die();
    }
}