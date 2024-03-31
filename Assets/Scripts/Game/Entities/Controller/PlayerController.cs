﻿using Core.Entities;
using Game.Entities.View;

namespace Game.Entities.Controller
{
    public partial class PlayerController : EntityController
    {
        private readonly PlayerModel model;
        private readonly PlayerView view;

        internal PlayerController(PlayerModel model, PlayerView view) : base(model, view)
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
    }
}