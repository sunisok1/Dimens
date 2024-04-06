using System;
using System.Collections;

namespace Core
{
    public interface ITurnRunner
    {
        event Action AtEndOfRound;
        event Action AtStartOfTurn;
        IEnumerator RunTurn();
        void EndTurn();
        void Confirm();
        void Cancel();
    }
}