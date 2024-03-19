using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
using Core.Action;
using Core.Cards;
using Core.Cards.CardFactory;
using UnityEngine;

namespace Core.Entities.Player
{
    public class Player : Entity, IUser, IPowerOwner
    {
        private readonly Deck deck = new(new RedFactory());
        private List<AbstractCard> handCards { get; } = new();

        public List<AbstractCard> HandCards => new(handCards);

        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public Vector3Int Position { get; private set; }

        public Player(string name, int health, int maxHealth, Vector3Int position) : base(name)
        {
            MaxHealth = maxHealth;
            Position = position;
            Health = health > maxHealth ? maxHealth : health;
        }

        #region Actions

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth; // 确保治疗后生命值不会超过最大值
            }
        }


        public void DrawCards(int num = 1)
        {
            var cards = deck.Draw(num);
            handCards.AddRange(cards);
            foreach (var card in cards)
            {
                OnCardDraw?.Invoke(this, new() { card = card });
            }
        }

        public void DiscardCards(List<AbstractCard> cards)
        {
            handCards.RemoveAll(cards.ToHashSet().Contains);
            foreach (var card in cards)
            {
                OnDiscard?.Invoke(this, new() { card = card });
            }
        }

        public void PlayCard(AbstractCard card, ITarget target)
        {
            handCards.Remove(card);
            card.Use(this, target);
            OnPlayCard?.Invoke(this, new() { card = card, });
        }

        #endregion

        public IEnumerator Play()
        {
            yield return new WaitWhile(() => true);
        }

        public void EndTurn()
        {
        }

        public void MoveTo(Vector3Int target)
        {
            EventSystem.InvokeEvent(this, new PlayerMoveEventArgs { origin = Position, target = target });
            Position = target;
        }

        #region Events

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

        #endregion
    }
}