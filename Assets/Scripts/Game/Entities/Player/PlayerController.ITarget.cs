using Core;
using UnityEngine;

namespace Game.Entities.Player
{
    public partial class PlayerController : ITarget
    {
        public void AddPower(AbstractPower power)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(DamageInfo damage)
        {
            model.CurHealth -= damage.num;
            view.UpdateHealth(model);
            if (model.CurHealth <= 0)
                Die();
        }

        public void Heal(int amount)
        {
            model.CurHealth = Mathf.Min(model.CurHealth + amount, model.MaxHealth);
            view.UpdateHealth(model);
        }

        public void Die()
        {
            Object.Destroy(view);
        }

        public bool HasPower(string powerId)
        {
            throw new System.NotImplementedException();
        }
    }
}