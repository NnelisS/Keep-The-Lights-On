using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowCutscene : MonoBehaviour
{
    private float timer = 35;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("YouLoseWindowText");
        }
    }
}
