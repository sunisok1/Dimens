using System.Collections;
using Core;

namespace Game.Entities.Controller
{
    public partial class PlayerController : ITurnRunner
    {
        public IEnumerator RunTurn()
        {
            Draw(3);
            yield break;
        }
    }
}