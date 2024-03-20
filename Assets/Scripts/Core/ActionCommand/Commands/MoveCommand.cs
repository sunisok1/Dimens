using UnityEngine;

namespace Core.ActionCommand.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly IMovable movableObject;
        private readonly Vector3Int origin;
        private readonly Vector3Int target;

        public MoveCommand(IMovable movableObject, Vector3Int origin, Vector3Int target)
        {
            this.movableObject = movableObject;
            this.origin = origin;
            this.target = target;
        }

        public void Execute()
        {
            movableObject.Move(origin, target);
        }
    }
}