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
    public Inventory playerInventory;

    public float destroyCurrent;
    public bool destroyLamp = false;
    public bool chosenIfDestroy = true;

    [Header("Sound")]
    public AudioSource lightTurnOff;
    public AudioSource lightTurnOn;
    public AudioSource lightBreak;

    public float timerUntillKill;

    private RandomizeSytem randomizeSystem;

    void Start()
    {
        lampsScript = FindObjectOfType<Lamps>();
        randomizeSystem = FindObjectOfType<RandomizeSytem>();
    }

    private void Update()
    {
        ChoosIfLampBreak();
    }

    public void ChoosIfLampBreak()
    {
        if (!lamp.activeInHierarchy)
        {
            StartCoroutine(LightTurnOff());
            timerUntillKill += Time.deltaTime;
            if (chosenIfDestroy)
            {
                destroyCurrent = Random.Range(0, 3);
                chosenIfDestroy = false;
            }

            if (timerUntillKill >= 25)
            {
                Debug.Log("Ur DED Lamp");
            }
        }
        else
        {
            timerUntillKill = 0;
        }

        if (destroyCurrent == 1)
        {
            StartCoroutine(LightBreak());
            destroyLamp = true;
        }
    }

    private void OnMouseEnter()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 4)
        {
            if (!lamp.activeInHierarchy)
            {
                see.SetActive(true);
            }
        }
    }

    private void OnMouseExit()
    {
        see.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.position)) < 5)
        {
            if (playerInventory.hasLightBulb == true)
            {
                destroyLamp = false;
                playerInventory.hasLightBulb = false;
            }

            if (!lamp.activeInHierarchy && destroyLamp == false)
            {
                StartCoroutine(LightTurnOn());
                lamp.SetActive(true);
                lampsScript.lamps.Add(lamp);
                chosenIfDestroy = true;
                see.SetActive(false);
                randomizeSystem.events.Add(this.GetComponent<Events>());
            }
        }
    }

    private IEnumerator LightTurnOn()
    {
        lightTurnOn.enabled = true;
        yield return new WaitForSeconds(1);
        lightTurnOn.enabled = false;
    }
    private IEnumerator LightTurnOff()
    {
        lightTurnOff.enabled = true;
        yield return new WaitForSeconds(1);
        lightTurnOff.enabled = false;
    }
    private IEnumerator LightBreak()
    {
        lightBreak.enabled = true;
        yield return new WaitForSeconds(1);
        lightBreak.enabled = false;
    }
}
