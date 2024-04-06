using System;
using Core;
using UnityEngine;

namespace Game.Entities.Player
{
    public partial class Player : IEnergyOwner
    {
        public event Action<int> OnEnergyChanged;

        private int energy;
        private int energyMaster;

        internal int Energy
        {
            get => energy;
            set
            {
                energy = Mathf.Min(0, value);
                OnEnergyChanged?.Invoke(energy);
            }
        }

        internal void Recharge()
        {
            // if (AbstractDungeon.player.hasRelic("Ice Cream")) {
            //     if (EnergyPanel.totalCount > 0) {
            //         AbstractDungeon.player.getRelic("Ice Cream").flash();
            //         AbstractDungeon.actionManager.addToTop(new RelicAboveCreatureAction(AbstractDungeon.player, AbstractDungeon.player.getRelic("Ice Cream")));
            //     }
            //
            //     EnergyPanel.addEnergy(this.energy);
            // } else if (AbstractDungeon.player.hasPower("Conserve")) {
            //     if (EnergyPanel.totalCount > 0) {
            //         AbstractDungeon.actionManager.addToTop(new ReducePowerAction(AbstractDungeon.player, AbstractDungeon.player, "Conserve", 1));
            //     }
            //
            //     EnergyPanel.addEnergy(this.energy);
            // } else {
            //     EnergyPanel.setEnergy(this.energy);
            // }

            Energy = energyMaster;
        }

        public void Use(int energy)
        {
            Energy -= energy;
        }
    }
}