using System;

namespace Core
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
}