using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Lamps lampsScript;

    [Header("Object info")]
    public GameObject lamp;

    void Start()
    {
        lampsScript = FindObjectOfType<Lamps>();
    }

    private void OnMouseDown()
    {
        if (!lamp.activeInHierarchy)
        {
            lamp.SetActive(true);
            lampsScript.lamps.Add(lamp);
        }
    }
}
