using Core;
using UnityEngine;

namespace Game.GameCommand.Commands
{
    public class MoveCommand : Command
    {
        public MoveCommand(IMovable movableObject, Vector3Int target) : base(() => { movableObject.MoveTo(target); })
        {
        }
    }
}