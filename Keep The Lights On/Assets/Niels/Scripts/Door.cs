using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Bed Info")]
    public Bed bedInfo;

    private Animator door;
    public bool activateDoorOpen = false;
    private bool doorIsOpen;

    [Header("StareTime")]
    public float timerUntillKill;
    public float timerUntillLeave;
    public int current;

    void Start()
    {
        door = GetComponent<Animator>();
    }

    void Update()
    {
        Kill();

        if (doorIsOpen)
        {
            CheckForBlanket();
            CheckToLeave();
        }

        if (activateDoorOpen)
        {
            current = 1;
            doorIsOpen = true;
        }
        else if (activateDoorOpen == false)
        {
            doorIsOpen = false;
            current = 2;
        }
        door.SetInteger("Current", current);
    }

    private void CheckForBlanket()
    {
        if (bedInfo.underBlanket == false && doorIsOpen == true)
        {
            timerUntillLeave = 0;
            timerUntillKill += Time.deltaTime;
        }

        if (bedInfo.underBlanket == true && doorIsOpen == true)
        {
            timerUntillLeave += Time.deltaTime;
        }
    }

    private void CheckToLeave()
    {
        if (timerUntillLeave >= 5)
        {
            timerUntillLeave = 0;
            timerUntillKill = 0;
            activateDoorOpen = false;
        }
    }

    private void Kill()
    {
        if (timerUntillKill >= 10)
        {
            timerUntillKill = 0;
            Debug.Log("ur DED");
        }
    }
}
