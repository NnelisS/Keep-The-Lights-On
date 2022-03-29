using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public bool activateThisEvent = false;
    public Lamps lamps;
    public Window window;
    public Door door;

    void Update()
    {
        if (activateThisEvent)
        {
            Debug.Log("choose");
            if (lamps != null)
            {
                Debug.Log("Lamps");
                lamps.chooseLamp = true;
                activateThisEvent = false;
            }
            if (window != null)
            {
                Debug.Log("Window");
                window.activateWindow = true;
                activateThisEvent = false;
            }
            if (door != null)
            {
                Debug.Log("Door");
                door.activateDoorOpen = true;
                activateThisEvent = false;
            }
        }
    }
}
