using System.Collections;
using Common;
using Core;
using Core.Card;
using UnityEngine;

namespace Game.Entities.Player
{
    public partial class PlayerController : ITurnRunner
    {
        private readonly CoroutineTrigger endTurnTrigger = new();

        private readonly MonoBehaviour coroutineHelper;

        public void EndTurn()
        {
            endTurnTrigger.Trigger();
        }

        public IEnumerator RunTurn()
        {
            Draw(3);

            Coroutine useCard = coroutineHelper.StartCoroutine(UseCard());

            yield return endTurnTrigger.WaitForTrigger();

            coroutineHelper.StopCoroutine(useCard);
        }

        private IEnumerator UseCard()
        {
            InitSelector(cards, card =>
            {
                if (card is IEnergyRequired energyRequired && energyRequired.Cost > model.Energy)
                    return false;
                return true;
            });
            yield return new WaitWhile(() => true);
        }
    }
}