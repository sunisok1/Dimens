using UnityEngine;

namespace Core.GameCommand.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly IMovable movableObject;
        private readonly Vector3Int target;

        public MoveCommand(IMovable movableObject, Vector3Int target)
        {
            this.movableObject = movableObject;
            this.target = target;
        }

        public void Execute()
        {
            movableObject.MoveTo(target);
        }
    }
}