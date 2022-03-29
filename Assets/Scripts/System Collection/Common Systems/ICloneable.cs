using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICloneable<T>
{
    int originalID { get; }

    T Copy();
}