using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPickup : MonoBehaviour
{
    public List<Lamp> lampsLightBulb = new List<Lamp>();
    public Transform player;
    public Inventory playerInventory;

    public GameObject pickupIcon;

    private void Update()
    {
        if (playerInventory.hasLightBulb == true)
        {
            pickupIcon.SetActive(false);
        }
    }

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
            pickupIcon.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 3)
        {
            pickupIcon.SetActive(false);
        }
    }
}
