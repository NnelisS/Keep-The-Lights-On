using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightCutscene : MonoBehaviour
{
    public Animator ambient;
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
        ambient.Play("Ambient Fade");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("YouLoseLightingText");
    }
}
