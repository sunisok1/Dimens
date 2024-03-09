using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.TurnSystem
{
    public class EventManager
    {
        private readonly Dictionary<Type, Delegate> eventHandlers = new();

        public void Subscribe<T>(EventHandler<T> handler) where T : EventArgs
        {
            Type type = typeof(T);
            eventHandlers.TryGetValue(type, out Delegate existingDelegate);
            eventHandlers[type] = Delegate.Combine(existingDelegate, handler);
        }

        public void Unsubscribe<T>(EventHandler<T> handler) where T : EventArgs
        {
            Type type = typeof(T);
            if (eventHandlers.TryGetValue(type, out Delegate existingDelegate))
            {
                Delegate newDelegate = Delegate.Remove(existingDelegate, handler);
                if (newDelegate == null)
                {
                    eventHandlers.Remove(type);
                }
                else
                {
                    eventHandlers[type] = newDelegate;
                }
            }
        }

        public void InvokeEvent<T>(object sender, T args) where T : EventArgs
        {
            Type type = typeof(T);
            if (!eventHandlers.TryGetValue(type, out Delegate delegateObj)) return;
            foreach (Delegate individualDelegate in delegateObj.GetInvocationList())
            {
                if (individualDelegate is not EventHandler<T> handler) continue;
                try
                {
                    handler(sender, args);
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }
        }
    }
}