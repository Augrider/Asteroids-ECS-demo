// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System;

namespace ScriptableObjectsSystem.Variables
{
    [Serializable]
    public class FloatReference
    {
        public bool useConstant = true;
        public float constantValue;
        public FloatVariable variable;

        public float value => useConstant ? constantValue : variable.runtimeValue;


        public FloatReference() { }

        public FloatReference(float value)
        {
            this.useConstant = true;
            this.constantValue = value;
        }


        public static implicit operator float(FloatReference reference)
        {
            return reference.value;
        }
    }
}