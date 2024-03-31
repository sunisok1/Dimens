using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Systems.TurnSystem
{
    public class TurnSystemController : MonoBehaviour
    {
        private TurnSystem turnSystem;
        [SerializeField] private TurnSystemView turnSystemView;

        private void Awake()
        {
            turnSystem = new TurnSystem();
        }

        public void Init(IEnumerable<ITurnRunner> runners)
        {
            foreach (ITurnRunner runner in runners)
            {
                turnSystem.AddRunner(runner);
            }

            StartCoroutine(RunTurnCycle());
        }

        private IEnumerator RunTurnCycle()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                ITurnRunner turnRunner = turnSystem.CurrentTurnRunner;

                yield return turnRunner.RunTurn();

                turnRunner = turnSystem.SwitchToNextRunner();
                turnSystemView.UpdateRunnerInfo(turnRunner);
            }
        }
    }
}