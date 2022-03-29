using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T current { get; private set; }


    protected virtual void Awake()
    {
        if (current)
            throw new TypeLoadException("More than one object of type " + this.GetType() + " detected!");

        current = this as T;
    }

    protected virtual void OnDestroy()
    {
        current = null;
    }
}