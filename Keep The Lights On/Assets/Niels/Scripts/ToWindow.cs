using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWindow : MonoBehaviour
{
    [Header("Window Info")]
    public Window window;

    private void OnMouseDown()
    {
        StartCoroutine(window.GoToWindow());
    }
}
