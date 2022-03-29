using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsSystem.Events
{
    /// <summary>
    /// Base class for events with 1 argument
    /// </summary>
    public abstract class GenericArgumentEvent<T> : GameEvent
    {
        protected Action<T> actions;


        public void Subscribe(Action<T> action) => actions += action;
        public void Unsubscribe(Action<T> action) => actions -= action;

        /// <summary>
        /// Raise event with arguments
        /// </summary>
        /// <remarks>
        /// First, subscribers with arguments will be raised, then GameEvent subscribers will be notified
        /// </remarks>
        public virtual void Raise(T argument)
        {
            actions?.Invoke(argument);
            Raise();
        }
    }


    /// <summary>
    /// Base class for events with 2 arguments
    /// </summary>
    public abstract class GenericArgumentEvent<T1, T2> : GameEvent
    {
        protected Action<T1, T2> actions;


        public void Subscribe(Action<T1, T2> action) => actions += action;
        public void Unsubscribe(Action<T1, T2> action) => actions -= action;

        /// <summary>
        /// Raise event with arguments
        /// </summary>
        /// <remarks>
        /// First, subscribers with arguments will be raised, then GameEvent subscribers will be notified
        /// </remarks>
        public virtual void Raise(T1 arg0, T2 arg1)
        {
            actions?.Invoke(arg0, arg1);
            Raise();
        }
    }


    /// <summary>
    /// Base class for events with 3 arguments
    /// </summary>
    public abstract class GenericArgumentEvent<T1, T2, T3> : GameEvent
    {
        protected Action<T1, T2, T3> actions;


        public void Subscribe(Action<T1, T2, T3> action) => actions += action;
        public void Unsubscribe(Action<T1, T2, T3> action) => actions -= action;

        /// <summary>
        /// Raise event with arguments
        /// </summary>
        /// <remarks>
        /// First, subscribers with arguments will be raised, then GameEvent subscribers will be notified
        /// </remarks>
        public virtual void Raise(T1 arg0, T2 arg1, T3 arg2)
        {
            actions?.Invoke(arg0, arg1, arg2);
            Raise();
        }
    }
}