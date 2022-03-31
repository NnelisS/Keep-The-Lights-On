using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCutscene : MonoBehaviour
{
    private float timer = 22.70f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("YouLoseDoorText");
        }
    }
}
