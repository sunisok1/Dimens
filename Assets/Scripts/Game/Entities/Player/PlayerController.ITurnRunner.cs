using System;
using System.Collections;
using Common;
using Core;
using Core.Card;
using Core.Entities;
using Game.GameCommand;
using Game.GameCommand.Commands;
using UnityEngine;

namespace Game.Entities.Player
{
    public partial class Player : ITurnRunner
    {
        private readonly CoroutineTrigger endTurnTrigger = new();
        private readonly CoroutineTrigger confirmTrigger = new();
        private readonly CoroutineTrigger cancelTrigger = new();

        private readonly MonoBehaviour coroutineHelper;

        public void EndTurn() => endTurnTrigger.Trigger();

        public void Confirm() => confirmTrigger.Trigger();

        public void Cancel() => cancelTrigger.Trigger();

        public event Action<CardController> OnUseCard;

        public IEnumerator RunTurn()
        {
            CommandInvoker.ExecuteCommand(new DrawCardAction(this, 3));

            Coroutine useCard = coroutineHelper.StartCoroutine(UseCardCycle());

            yield return endTurnTrigger.WaitForTrigger();

            coroutineHelper.StopCoroutine(useCard);
        }

        private IEnumerator UseCardCycle()
        {
            while (true)
            {
                InitSelector(cards, card =>
                {
                    if (card is IEnergyRequired energyRequired && energyRequired.Cost > Energy)
                        return false;
                    return true;
                });

                selectedCard = null;

                yield return SelectCard();

                AbstractEntity selectedTarget = null;
                yield return selectedCard.GetTarget(target => selectedTarget = target);

                confirmTrigger.onTrigger = () => { CommandInvoker.ExecuteCommand(new UseCardAction(this, selectedCard, selectedTarget)); };
                yield return confirmTrigger.WaitForTrigger();
            }
        }
    }

    internal class UseCardAction : Command
    {
        public UseCardAction(ICardOwner cardOwner, CardController selectedCard, AbstractEntity target) : base(() => cardOwner.UseCard(selectedCard, target))
        {
        }
    }
}