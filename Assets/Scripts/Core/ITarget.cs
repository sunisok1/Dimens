namespace Core
{
    public interface ITarget
    {
        void TakeDamage(DamageInfo damage);
        void Heal(int amount);
        void Die();

        void AddPower(AbstractPower power);
        bool HasPower(string powerId);
    }
}