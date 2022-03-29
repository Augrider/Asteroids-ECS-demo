using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsSystem.Events
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with.")]
        public GameEvent gameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent response;


        void OnEnable()
        {
            gameEvent.Subscribe(this);
        }

        void OnDisable()
        {
            gameEvent.Unsubscribe(this);
        }


        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}