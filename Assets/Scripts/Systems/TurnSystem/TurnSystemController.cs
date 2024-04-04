using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Systems.TurnSystem
{
    public class TurnSystemController : MonoBehaviour
    {
        private readonly TurnSystem turnSystem = new();
        [SerializeField] private TurnSystemView turnSystemView;

        public void Init(IEnumerable<ITurnRunner> runners)
        {
            foreach (ITurnRunner runner in runners)
            {
                turnSystem.AddRunner(runner);
            }

            turnSystem.Init(out ITurnRunner turnRunner);
            StartCoroutine(RunTurnCycle());
            return;

            IEnumerator RunTurnCycle()
            {
                do
                {
                    turnSystem.turnNum++;
                    Debug.Log($"{turnRunner} starts turn.turnNum:{turnSystem.turnNum}");
                    turnSystemView.UpdateTurnNumText(turnSystem.turnNum);
                    turnSystemView.UpdateRunnerInfo(turnRunner);

                    yield return turnRunner.RunTurn();
                } while (turnSystem.SwitchToNextRunner(out turnRunner));
            }
        }
    }
}