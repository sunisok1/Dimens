using System.Collections;
using Common;
using Core;

namespace Game.Entities.Player
{
    public partial class PlayerController : ITurnRunner
    {
        private readonly CoroutineTrigger endTurnTrigger = new();

        public void EndTurn()
        {
            endTurnTrigger.Trigger();
        }

        public IEnumerator RunTurn()
        {
            Draw(3);
            yield return endTurnTrigger.WaitForTrigger();
        }
    }
}