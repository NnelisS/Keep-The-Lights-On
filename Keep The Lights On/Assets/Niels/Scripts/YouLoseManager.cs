using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLoseManager : MonoBehaviour
{
    public Animator fade;
    public Animator ambient;
    public string animName;

    public void PlayGame()
    {
        StartCoroutine(PlayGameFade());
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuFade());
    }

    private IEnumerator PlayGameFade()
    {
        ambient.Play("Ambient Fade");
        fade.Play(animName);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }    

    private IEnumerator MainMenuFade()
    {
        ambient.Play("Ambient Fade");
        fade.Play(animName);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }
}
