using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Common
{
    public class CoroutineHelper : MonoBehaviour
    {
    }

    public class CoroutineTrigger
    {
        private bool triggered;

        public Action onTrigger;

        public void Trigger()
        {
            triggered = true;
        }

        public IEnumerator WaitForTrigger()
        {
            yield return new WaitUntil(() => triggered);
            triggered = false;
            onTrigger?.Invoke();
        }
    }

    public class TaskTrigger
    {
        private bool triggered;

        public void Trigger()
        {
            triggered = true;
        }

        public async Task WaitForTrigger()
        {
            while (triggered == false)
            {
                await Task.Yield();
            }

            triggered = false;
        }
    }
}