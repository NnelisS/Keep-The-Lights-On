using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldTime : MonoBehaviour
{
    [Header("Settings")]
    public float beginTime = 1;
    public float endTime = 720;

    [Header("Timer Count Settings")]
    public bool switchTimer = false;
    public bool turnOnTimer = true;

    [Header("info")]
    public Bed eyeInfo;

    public TextMeshPro timeText;

    void Start()
    {
        timeText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (turnOnTimer)
        {
            beginTime += Time.deltaTime;
        }
        DisplayTime(beginTime, endTime);

        if (beginTime == endTime)
        {
            if (eyeInfo.timeEyesAreClosed >= 120)
            {
                Debug.Log("you win");
            }
        }
    }

    #region Display Time
    private void DisplayTime(float startTime, float exitTime)
    {
        // when time reaches endTime it restart or will end the game
        if (startTime >= exitTime)
        {
            beginTime = 0;
        }

        // set time to hours and minutes
        float hours = Mathf.FloorToInt(startTime / 120);
        float minutes = Mathf.FloorToInt(startTime % 120);

        // change timer type with bool
        if (switchTimer == false)
        {
            timeText.text = string.Format("{0:0} AM", hours);
        }
        else
        {
            timeText.text = string.Format("{0:0}:{1:00}", hours, minutes);
        }
    }
    #endregion

}
