using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Variables
{
    /// <summary>
    /// Base class for storing value in scriptable object
    /// </summary>
    /// <typeparam name="T">Type of value</typeparam>
    public abstract class BaseVariableObject<T> : ScriptableObject, IVariableSync
    {
#if UNITY_EDITOR
        [Multiline]
        public string developerDescription = "";
#endif

        public T runtimeValue => _runtimeValue;
        [SerializeField] protected T _runtimeValue;

        [SerializeField] internal T initialValue;

        public event Action<T> valueChanged;


        void OnEnable()
        {
            ResetRuntime();
        }


        public void SetValue(T value)
        {
            this._runtimeValue = value;
            InvokeOnValueChanged();
        }


        internal void ResetRuntime() => SetValue(initialValue);
        internal void SynchronizeInitial() => this.initialValue = runtimeValue;
        internal void InvokeOnValueChanged() => valueChanged?.Invoke(runtimeValue);

        void IVariableSync.ResetRuntime() => ResetRuntime();
        void IVariableSync.SynchronizeInitial() => SynchronizeInitial();
        void IVariableSync.InvokeOnValueChanged() => InvokeOnValueChanged();


        public static implicit operator T(BaseVariableObject<T> variable) => variable.runtimeValue;
    }
}