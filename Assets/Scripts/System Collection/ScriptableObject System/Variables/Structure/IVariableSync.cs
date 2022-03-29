using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Variables
{
    internal interface IVariableSync
    {
        void ResetRuntime();
        void SynchronizeInitial();
        void InvokeOnValueChanged();
    }
}