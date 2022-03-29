using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class Collider2DSizeFitter : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;


    void Awake()
    {
        SetColliderSize();
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        SetColliderSize();
    }
#endif

    private void SetColliderSize()
    {
        var rectTransform = GetComponent<RectTransform>();
        boxCollider2D.size = rectTransform.rect.size;
    }
}
