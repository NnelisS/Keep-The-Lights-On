using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private float timer = 95;
    public Animator sound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            sound.Play("Ambient Fade");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
