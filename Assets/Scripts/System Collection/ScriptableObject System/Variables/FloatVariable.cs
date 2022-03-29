// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

namespace ScriptableObjectsSystem.Variables
{
    [CreateAssetMenu(menuName = "Scriptable Variables/float", order = 51)]
    public class FloatVariable : BaseVariableObject<float>
    {
        public void ApplyChange(float amount)
        {
            SetValue(_runtimeValue + amount);
        }
    }
}