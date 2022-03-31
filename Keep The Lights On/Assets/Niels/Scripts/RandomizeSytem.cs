using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSytem : MonoBehaviour
{
    [Header("Info")]
    public int current;

    public List<Events> events = new List<Events>();

    public bool chooseEvent= false;
    public bool chosenEvent = false;

    public float timerUntillEvent;
    public float timerUntillDifficultChange;
    public float timerChange = 50;

    private void Start()
    {
        timerUntillEvent = timerChange;
    }

    void Update()
    {
        ChangeDifficulties();
        timerUntillDifficultChange += Time.deltaTime;

        timerUntillEvent -= Time.deltaTime;

        if (timerUntillEvent <= 0)
        {
            chooseEvent = true;
            timerUntillEvent = timerChange;
        }

        if (chooseEvent)
        {
            StartCoroutine(ChooseOutEvent());
        }

        if (chosenEvent)
        {
            events[current].activateThisEvent = true;
            events.RemoveAt(current);
            chosenEvent = false;
        }

        if ( timerUntillDifficultChange >= 720)
        {
            Debug.Log("End");
        }
    }

    #region Difficulty changer
    private void ChangeDifficulties()
    {
        if (timerUntillDifficultChange == 0)
        {
            timerChange = Random.Range(25, 60);
        }          
        
        if (timerUntillDifficultChange == 120)
        {
            timerChange = Random.Range(25, 50);
        }   
        
        if (timerUntillDifficultChange == 240)
        {
            timerChange = Random.Range(25, 45);
        } 
        
        if (timerUntillDifficultChange == 360)
        {
            timerChange = Random.Range(25, 40);
        }
        
        if (timerUntillDifficultChange == 480)
        {
            timerChange = Random.Range(25, 35);
        } 
        
        if (timerUntillDifficultChange == 600)
        {
            timerChange = Random.Range(25, 30);
        }
    }
    #endregion

    private IEnumerator ChooseOutEvent()
    {
        current = Random.Range(0, events.Count);
        chooseEvent = false;
        chosenEvent = true;
        yield return current;
    }
}
