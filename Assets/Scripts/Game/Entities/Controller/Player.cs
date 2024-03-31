using Core;
using Core.Entities;
using Game.Entities.View;
using UnityEngine;

namespace Game.Entities.Controller
{
    public class Player : EntityController, ITarget
    {
        private readonly PlayerModel model;
        private readonly PlayerView view;

        public Player(PlayerModel model, PlayerView view) : base(model, view)
        {
            this.model = model;
            this.view = view;
        }

        public void SetInfo(int health, int maxHealth)
        {
            model.CurHealth = health;
            model.MaxHealth = maxHealth;
            view.UpdateHealth(model);
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

        public void AddPower(AbstractPower power)
        {
            throw new System.NotImplementedException();
        }

        public bool HasPower(string powerId)
        {
            throw new System.NotImplementedException();
        }
    }
}