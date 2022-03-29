using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IECSHandler
{
    bool worldExists { get; }

    void AddEvent<T>() where T : struct;
    void AddEvent<T>(in T component) where T : struct;
}
