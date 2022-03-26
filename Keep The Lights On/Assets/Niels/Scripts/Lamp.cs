using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Lamps lampsScript;

    [Header("UI")]
    public GameObject see;

    [Header("Object info")]
    public GameObject lamp;

    [Header("Player")]
    public Transform player;

    void Start()
    {
        lampsScript = FindObjectOfType<Lamps>();
    }

    private void OnMouseEnter()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 4)
        {
            see.SetActive(true);
        }
        else
        {
            see.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        see.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!lamp.activeInHierarchy)
        {
            lamp.SetActive(true);
            lampsScript.lamps.Add(lamp);
        }
/*        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 5)
        {
            Debug.Log("in distance");

        }*/
    }

/*    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position, 4);
    }*/
}
