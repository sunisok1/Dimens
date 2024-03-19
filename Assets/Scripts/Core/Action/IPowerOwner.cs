using System;
using Core.Cards;

namespace Core.Action
{
    public interface IPowerOwner
    {
        public event EventHandler<DamageGiveArgs> AtDamageGive;
        public event EventHandler<DamageGiveArgs> AtDamageFinalGive;
        public event EventHandler<DamageGiveArgs> AtDamageReceive;
        public event EventHandler AtStartOfTurn;
        public event EventHandler DuringTurn;
        public event EventHandler AtStartOfTurnPostDraw;
        public event EventHandler<bool> AtEndOfTurn;
        public event EventHandler<bool> AtEndOfTurnPreEndTurnCards;
        public event EventHandler AtEndOfRound;
        public event EventHandler OnScry;
        public event EventHandler<DamageAllEnemiesArgs> OnDamageAllEnemies;
        public event EventHandler<HealArgs> OnHeal;
        public event EventHandler<AttackedArgs> OnAttacked;
        public event EventHandler<AttackedArgs> OnAttackedToChangeDamage;
        public event EventHandler<AttackedArgs> OnAttackToChangeDamage;
        public event EventHandler<AttackedArgs> OnInflictDamage;
        public event EventHandler<CardDrawArgs> OnCardDraw;
        public event EventHandler<DiscardArgs> OnDiscard;
        public event EventHandler<PlayCardArgs> OnPlayCard;
        public event EventHandler OnUseCard;
        public event EventHandler OnAfterUseCard;
        public event EventHandler WasHpLost;
        public event EventHandler OnSpecificTrigger;
        public event EventHandler TriggerMarks;
        public event EventHandler OnDeath;
        public event EventHandler OnChannel;
        public event EventHandler AtEnergyGain;
        public event EventHandler OnExhaust;
        public event EventHandler OnChangeStance;
    }

    public class DamageGiveArgs : EventArgs
    {
        public float damage;
        public DamageInfo.DamageType type;
        public AbstractCard card;
    }

    public class DamageAllEnemiesArgs : EventArgs
    {
        public int[] damage;
    }

    public class HealArgs : EventArgs
    {
        public int healAmount;
    }

    public class AttackedArgs : EventArgs
    {
        public DamageInfo info;
        public int damageAmount;
        private ITarget target;
    }

    public class CardDrawArgs : EventArgs
    {
        public AbstractCard card;
    }

    public class DiscardArgs : EventArgs
    {
        public AbstractCard card;
    }

    public class PlayCardArgs : EventArgs
    {
        public AbstractCard card;
        public ITarget target;
    }
}