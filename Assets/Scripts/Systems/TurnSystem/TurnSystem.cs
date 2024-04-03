using System.Collections.Generic;
using Core;

namespace Systems.TurnSystem
{
    internal class TurnSystem
    {
        public int turnNum;

        private readonly LinkedList<ITurnRunner> runnersLinkedList = new();
        private LinkedListNode<ITurnRunner> currentRunnerNode;

        internal int RunnerCount => runnersLinkedList.Count;


        internal void Init(out ITurnRunner firstTurnRunner)
        {
            currentRunnerNode = runnersLinkedList.First;
            firstTurnRunner = currentRunnerNode.Value;
        }

        internal void AddRunner(ITurnRunner runner)
        {
            runnersLinkedList.AddLast(runner);
        }

        internal ITurnRunner CurrentTurnRunner => currentRunnerNode.Value;

        internal bool SwitchToNextRunner(out ITurnRunner turnRunner)
        {
            turnRunner = null;
            if (runnersLinkedList.Count <= 1) return false;
            currentRunnerNode = currentRunnerNode.Next ?? runnersLinkedList.First;
            turnRunner = currentRunnerNode.Value;
            return true;
        }
    }
}