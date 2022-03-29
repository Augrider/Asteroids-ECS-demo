using UnityEditor;
using UnityEngine;

namespace ScriptableObjectsSystem.Variables
{
    [CustomEditor(typeof(BaseVariableObject<>), editorForChildClasses: true)]
    public class BaseVariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var variableSync = target as IVariableSync;

            GUILayout.Space(10);

            GUI.enabled = Application.isPlaying;

            if (GUILayout.Button("Raise on value changed event"))
                variableSync.InvokeOnValueChanged();

            GUILayout.Space(10);

            if (GUILayout.Button("Reset runtime value"))
                variableSync.ResetRuntime();

            if (GUILayout.Button("Synchronize initial value"))
                variableSync.SynchronizeInitial();
        }
    }
}
