using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPickup : MonoBehaviour
{
    public List<Lamp> lampsLightBulb = new List<Lamp>();
    public Transform player;
    public Inventory playerInventory;

    private void OnMouseDown()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 3)
        {
            playerInventory.hasLightBulb = true;
        }
    }

    private void OnMouseEnter()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 3)
        {
            Debug.Log("Inside");
        }
    }

    private void OnMouseExit()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 3)
        {
            Debug.Log("Inside");
        }
    }
}
