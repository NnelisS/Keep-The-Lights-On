using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator door;
    public bool activateDoorOpen = false;

    [Header("StareTime")]
    public float timerUntillKill;
    public int current;

    void Start()
    {
        door = GetComponent<Animator>();
    }

    void Update()
    {
        if (activateDoorOpen)
        {
            current = 1;
        }
        else if (activateDoorOpen == false)
        {
            current = 2;
        }
        door.SetInteger("Current", current);
    }
}
