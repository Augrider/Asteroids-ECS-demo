using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Variables
{
    [CreateAssetMenu(menuName = "Scriptable Variables/Vector3", order = 51)]
    public class Vector3Variable : BaseVariableObject<Vector3>
    {
        public void ApplyChange(Vector3 amount)
        {
            SetValue(_runtimeValue + amount);
        }
    }
}