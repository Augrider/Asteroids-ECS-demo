using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Events
{
    [CreateAssetMenu(menuName = "Game Event", order = 51)]
    public class GameEvent : ScriptableObject
    {
        private List<IGameEventListener> listeners = new List<IGameEventListener>();


        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }


        public void Subscribe(IGameEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void Unsubscribe(IGameEventListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}