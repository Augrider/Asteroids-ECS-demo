using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Variables
{
    [CreateAssetMenu(menuName = "Scriptable Variables/Vector2", order = 51)]
    public class Vector2Variable : BaseVariableObject<Vector2>
    {
        public void ApplyChange(Vector2 amount)
        {
            SetValue(_runtimeValue + amount);
        }
    }
}