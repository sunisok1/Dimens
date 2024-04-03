using System.Collections;
using UnityEngine;

namespace Common
{
    public class CoroutineTrigger : MonoBehaviour
    {
        private bool triggered;

        public void Trigger()
        {
            triggered = true;
        }

        public IEnumerator WaitForTrigger()
        {
            yield return new WaitUntil(() => triggered);
            triggered = false;
        }
    }
}