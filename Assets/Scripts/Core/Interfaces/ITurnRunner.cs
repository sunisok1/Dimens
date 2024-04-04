using System.Collections;

namespace Core
{
    public interface ITurnRunner
    {

        IEnumerator RunTurn();
        void EndTurn();
        void Confirm();
        void Cancel();
    }
}