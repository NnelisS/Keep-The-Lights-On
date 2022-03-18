using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InToBed : MonoBehaviour
{
    public bool intoBed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            intoBed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            intoBed = false;
        }
    }
}
