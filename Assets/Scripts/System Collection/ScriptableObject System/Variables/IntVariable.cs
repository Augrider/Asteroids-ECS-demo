using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableObjectsSystem.Variables
{
    [CreateAssetMenu(menuName = "Scriptable Variables/int", order = 51)]
    public class IntVariable : BaseVariableObject<int>
    {
        public void AddValue(int amount)
        {
            SetValue(_runtimeValue + amount);
        }


        public static implicit operator float(IntVariable variable) => variable.runtimeValue;
    }
}