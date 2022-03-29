using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Events
{
    [System.Serializable]
    public class CodedGameEventListener : IGameEventListener
    {
        [SerializeField] private GameEvent gameEvent;
        private Action action;


        public void OnEnable(Action action)
        {
            gameEvent?.Subscribe(this);
            this.action = action;
        }

        public void OnDisable()
        {
            gameEvent?.Unsubscribe(this);
            this.action = null;
        }


        public void OnEventRaised()
        {
            action?.Invoke();
        }
    }
}