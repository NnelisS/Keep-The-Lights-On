using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonFade : MonoBehaviour
{
    public GameObject crosshair;

    public Animator fade;
    public string nameAnim;
    public string nameScene;
    public bool playOrQuit = false;

    public Animator sound;

    private void OnMouseDown()
    {
        if (playOrQuit == false)
        {
            StartCoroutine(PlayGame());
        }
        else if (playOrQuit)
        {
            StartCoroutine(QuitGame());
        }
    }

    private void OnMouseEnter()
    {
        crosshair.SetActive(true);
    }

    private void OnMouseExit()
    {
        crosshair.SetActive(false);
    }

    private IEnumerator PlayGame()
    {
        fade.Play(nameAnim);
        sound.Play("Ambient Fade");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nameScene);
    }    
    private IEnumerator QuitGame()
    {
        fade.Play(nameAnim);
        sound.Play("Ambient Fade");
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
}
