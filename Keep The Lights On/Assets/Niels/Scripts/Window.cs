using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Window : MonoBehaviour
{
    public bool activateWindow = false;
    public float speed = 10;
    private Rigidbody rb;

    [Header("Player")]
    public PlayerMovement playermovement;
    public MouseLook playerLook;
    public GameObject flashlight;
    public GameObject hand;
    public Animator handAnim;
    public AudioSource footstep;

    [Header("Camera")]
    public Animator cameraChanger;
    public string camName;

    [Header("Window")]
    public Cloth leftCloth;
    public Cloth RightCloth;
    public BoxCollider boxCol;
    public string handAnimName;
    private bool windowIsOpen = false;
    public float timerUntillKill;

    [Header("Monster")]
    public Animator monster;
    public string animIn;
    public string animOut;

    [Header("Sound")]
    public AudioSource windowOpen;

    private RandomizeSytem randomizeSystem;

    public bool movementEnabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomizeSystem = FindObjectOfType<RandomizeSytem>();
    }

    void Update()
    {
        CheckWindow();
        Kill();

        if (activateWindow)
        {
            StartCoroutine(windowOpenSound());   
            leftCloth.externalAcceleration = new Vector3(0, 0, 4);
            RightCloth.externalAcceleration = new Vector3(0, 0, -4);
        }
        else if (activateWindow == false)
        {
            leftCloth.externalAcceleration = new Vector3(0, 0, 0);
            RightCloth.externalAcceleration = new Vector3(0, 0, 0);
        }

        if (movementEnabled)
        {
            WindowClose();
        }

        if (activateWindow == true)
        {
            WindowPullDown(); 
        }
        else if (activateWindow == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0.301f, transform.localPosition.z);
            rb.velocity = Vector3.zero;
        }
    }

    private void CheckWindow()
    {
        if (windowIsOpen == true)
        {
            monster.Play(animIn);
            timerUntillKill += Time.deltaTime;
        }
        else if (windowIsOpen == false)
        {
            monster.Play(animOut);
        }
    }

    private void Kill()
    {
        if (timerUntillKill >= 30)
        {
            timerUntillKill = 0;
            SceneManager.LoadScene("YouLoseWindow");
            Debug.Log("Ur DED window");
        }
    }

    private void WindowIsPulledDown()
    {
        if (transform.localPosition.y <= 0.3f)
        {
            windowIsOpen = false;
            activateWindow = false;
            timerUntillKill = 0;
            randomizeSystem.events.Add(this.GetComponent<Events>());
            StartCoroutine(OutWindow());
        }
    }

    private void WindowPullDown()
    {
        if (transform.localPosition.y >= 0.7f)
        {
            rb.velocity = Vector3.zero;
        }
        else if (transform.localPosition.y <= 0.7f)
        {
            windowIsOpen = true;
            rb.velocity = transform.forward * speed;
        }

        WindowIsPulledDown();
        //var pos = transform.position;
        //pos.y = Mathf.Clamp(transform.position.y, 0f, 0.7f);
    }

    private void WindowClose()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(OutWindow());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        }
    }

    public IEnumerator GoToWindow()
    {
        footstep.enabled = false;
        hand.SetActive(true);
        cameraChanger.Play(camName);
        flashlight.SetActive(false);
        boxCol.enabled = false;
        playermovement.enabled = false;
        yield return new WaitForSeconds(0.5f);
        movementEnabled = true;
    }

    public IEnumerator OutWindow()
    {
        handAnim.Play(handAnimName);
        cameraChanger.Play("CameraChange");
        movementEnabled = false;
        flashlight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        playermovement.enabled = true;
        playerLook.enabled = true;
        boxCol.enabled = true;
        hand.SetActive(false);
    }

    private IEnumerator windowOpenSound()
    {
        windowOpen.enabled = true;
        yield return new WaitForSeconds(5);
        windowOpen.enabled = false;
    }
}
