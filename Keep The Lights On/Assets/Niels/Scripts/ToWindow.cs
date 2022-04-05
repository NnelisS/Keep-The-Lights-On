using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWindow : MonoBehaviour
{
    [Header("Window Info")]
    public Window window;
    public MouseLook mouseLook;

    private void OnMouseDown()
    {
        mouseLook.enabled = false;
        StartCoroutine(window.GoToWindow());
    }
}
