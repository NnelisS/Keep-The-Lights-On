using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLive : MonoBehaviour
{
    [Header("Player Info")]
    public Animator eyeFade;

    [Header("Player")]
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;

    [Header("Sound")]
    public AudioSource footstep;
    public AudioSource heartBeat;
    public Animator heartBeatAnim;
    public AudioSource lastBreath;
    public Animator ambient;

    public bool timerOn = false;
    public bool usable = false;
    public bool oneTime = false;
    public float timer;

    private void Update()
    {
        CheckHeartBeat();

        if (timerOn)
        {
            heartBeat.enabled = true;
            timer += Time.deltaTime;
            usable = true;
            if (timer >= 3)
            {
                footstep.enabled = false;
                heartBeatAnim.Play("HeartbeatFade");
                ambient.Play("Ambient Fade");
                StartCoroutine(EndGame());
                heartBeat.enabled = false;
                lastBreath.enabled = true;
                eyeFade.Play("Dead");
                Debug.Log("Ur DED path");
            }
        }
        else if (timerOn == false && usable == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            oneTime = false;
            usable = false;
            timer = 0.01f;
            if (usable == false && oneTime == false)
            {
                StartCoroutine(HeartBeatFade());
            }
        }
    }

    private void CheckHeartBeat()
    {
        if (timer <= 0.29f)
        {
            heartBeat.pitch = 1.0f;
        }
        if (timer >= 0.3f)
        {
            heartBeat.pitch = 1.1f;
            /*heartBeat.enabled = true;*/
        }
        if (timer >= 0.6f)
        {
            heartBeat.pitch = 1.2f;
        }
        if (timer >= 1.0f)
        {
            heartBeat.pitch = 1.3f;
        }
        if (timer >= 1.3f)
        {
            heartBeat.pitch = 1.4f;
        }
        if (timer >= 1.6f)
        {
            heartBeat.pitch = 1.5f;
        }
        if (timer >= 2.0f)
        {
            heartBeat.pitch = 1.6f;
        }
        if (timer >= 2.3f)
        {
            heartBeat.pitch = 1.7f;
        }
        if (timer >= 2.6f)
        {
            heartBeat.pitch = 1.8f;
        }
        if (timer >= 3.0f)
        {
            heartBeat.pitch = 1.9f;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FootstepPath"))
        {
            Debug.Log("go");
            eyeFade.Play("KillFade");
            timerOn = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FootstepPath"))
        {
            eyeFade.Play("NormalFade");
            timerOn = false;
        }
    }

    private IEnumerator HeartBeatFade()
    {
        heartBeatAnim.Play("HeartbeatFade");
        yield return new WaitForSeconds(1);
        heartBeat.enabled = false;
        oneTime = true;
    }

    private IEnumerator EndGame()
    {
        footstep.enabled = false;
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("YouLoseFootstep");
    }
}