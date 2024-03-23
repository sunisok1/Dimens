using Classes;
using Classes.Entities.Controller;
using Core.Entities.View;
using UnityEngine;

namespace Core.Entities.Controller
{
    public class Player : EntityController, IHealthController
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
    }
}