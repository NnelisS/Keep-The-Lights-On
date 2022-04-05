using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalTime : MonoBehaviour
{
    private float totalTime;
    private TextMeshPro text;

    void Start()
    {
        totalTime = PlayerPrefs.GetFloat("TimeEyesAreClosed");
    }

    void Update()
    {
        this.text.text = string.Format("Ur total time was {0}", Mathf.RoundToInt(totalTime));
    }
}
