using System.Collections.Generic;
using Core;
using Core.Card;
using UnityEngine;

namespace Game.Entities.Player
{
    public partial class PlayerController : ITarget
    {
        public void AddPower(AbstractPower power)
        {
            model.Powers.Add(power);
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

        public void Draw(int amount)
        {
            var cardControllers = new List<CardController>();
            for (var i = 0; i < amount; i++)
            {
                cardControllers.Add(new(model.Deck.Draw()));
            }

            AddCard(cardControllers);
        }
    }
}