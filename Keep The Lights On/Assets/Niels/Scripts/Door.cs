using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [Header("Bed Info")]
    public Bed bedInfo;

    [Header("Kill")]
    public Animator fade;
    public Animator ambient;
    public Animator monster;

    private Animator door;
    public bool activateDoorOpen = false;
    private bool doorIsOpen;

    [Header("StareTime")]
    public float timerUntillKill;
    public float timerUntillLeave;
    public int current;

    [Header("Sound")]
    public AudioSource doorCreak;
    public AudioSource monsterBreath;

    private RandomizeSytem randomizeSystem;

    void Start()
    {
        door = GetComponent<Animator>();
        randomizeSystem = FindObjectOfType<RandomizeSytem>();
    }

    void Update()
    {
        Kill();

        if (doorIsOpen)
        {
            monsterBreath.enabled = true;   
            CheckForBlanket();
            CheckToLeave();
        }
        else if (doorIsOpen == false)
        {
            monsterBreath.enabled = false;
        }

        if (activateDoorOpen)
        {
            StartCoroutine(DoorCreak());
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
            randomizeSystem.events.Add(this.GetComponent<Events>());
        }
    }

    private void Kill()
    {
        if (timerUntillKill >= 20)
        {
            timerUntillKill = 0;
            StartCoroutine(DoorKill());
            Debug.Log("ur DED");
        }
    }

    private IEnumerator DoorCreak()
    {
        doorCreak.enabled = true;
        yield return new WaitForSeconds(6);
        doorCreak.enabled = false;
    }   
    
    private IEnumerator DoorKill()
    {
        monster.Play("MonsterFade");
        fade.Play("Dead");
        ambient.Play("Ambient Fade");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("YouLoseDoor");
    }
}
