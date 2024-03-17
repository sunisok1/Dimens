using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Common
{
    public static class CoroutineManager
    {
        private static readonly Dictionary<object, HashSet<Coroutine>> coroutineDictionary = new();

        private static readonly CoroutineRunner CoroutineRunner;

        static CoroutineManager()
        {
            GameObject gameObject = new("CoroutineManager");
            CoroutineRunner = gameObject.AddComponent<CoroutineRunner>();
        }

        public static Coroutine StartCoroutine(this object sender, IEnumerator routine)
        {
            coroutineDictionary.TryAdd(sender, new());

            Coroutine coroutine = CoroutineRunner.StartCoroutine(routine);

            coroutineDictionary[sender].Add(coroutine);
            return coroutine;
        }

        public static void StopCoroutine(this object sender, Coroutine coroutine)
        {
            if (!coroutineDictionary.TryGetValue(sender, out HashSet<Coroutine> coroutines)) return;
            if (!coroutines.Remove(coroutine)) return;
            CoroutineRunner.StopCoroutine(coroutine);
        }

        public static void StopAllCoroutine(this object sender)
        {
            if (!coroutineDictionary.TryGetValue(sender, out HashSet<Coroutine> coroutines)) return;
            foreach (Coroutine coroutine in coroutines)
            {
                CoroutineRunner.StopCoroutine(coroutine);
            }

            coroutineDictionary.Remove(sender);
        }
    }
}