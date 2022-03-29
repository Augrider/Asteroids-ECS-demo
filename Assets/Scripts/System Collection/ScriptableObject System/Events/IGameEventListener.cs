using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Events
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
}
