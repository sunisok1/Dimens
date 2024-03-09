using UnityEngine;

namespace Core.TurnSystem
{
    public class TurnSystem : MonoBehaviour
    {
        private readonly StateMachine stateMachine = new();

        private void Start()
        {
            // stateMachine.ChangeState();
        }
    }
}