using System.Collections.Generic;
using Core;

namespace Systems.TurnSystem
{
    internal class TurnSystem
    {
        private readonly LinkedList<ITurnRunner> runnersLinkedList = new();
        private LinkedListNode<ITurnRunner> currentRunnerNode;

        internal int RunnerCount => runnersLinkedList.Count;

        internal void AddRunner(ITurnRunner runner)
        {
            runnersLinkedList.AddLast(runner);
            currentRunnerNode ??= runnersLinkedList.First;
        }

        internal ITurnRunner CurrentTurnRunner => currentRunnerNode.Value;

        internal ITurnRunner SwitchToNextRunner()
        {
            currentRunnerNode = currentRunnerNode.Next ?? runnersLinkedList.First;
            return currentRunnerNode.Value;
        }
    }
}