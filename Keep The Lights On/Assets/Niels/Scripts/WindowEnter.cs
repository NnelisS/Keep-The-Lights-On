using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEnter : MonoBehaviour
{
    [Header("Window")]
    public BoxCollider windowCollider;

    private void Start()
    {
        windowCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            windowCollider.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            windowCollider.enabled = false;
        }
    }
}
