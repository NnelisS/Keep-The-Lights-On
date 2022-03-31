using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightCutscene : MonoBehaviour
{
    private float timer = 36.50f;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            StartCoroutine(CloseCutscene());
        }
    }

    private IEnumerator CloseCutscene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("YouLoseLightingText");
    }
}
