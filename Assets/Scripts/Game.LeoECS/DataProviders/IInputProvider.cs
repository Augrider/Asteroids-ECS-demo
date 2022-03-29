using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProvider
{
    Vector2 movementInput { get; }
    bool shootPrimary { get; }
    bool shootSpecial { get; }
}
