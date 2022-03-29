// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

namespace ScriptableObjectsSystem.Variables
{
    [CreateAssetMenu(menuName = "Scriptable Variables/string", order = 51)]
    public class StringVariable : BaseVariableObject<string> { }
}