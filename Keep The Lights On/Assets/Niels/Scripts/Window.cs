using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Camera")]
    public Animator cameraChanger;
    public string camName;

    [Header("Window")]
    public BoxCollider boxCol;
    public string handAnimName;
    private bool windowIsOpen = false;
    public float timerUntillKill;

    [Header("Monster")]
    public Animator monster;
    public string animIn;
    public string animOut;

    public bool movementEnabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckWindow();
        Kill();

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
        if (timerUntillKill >= 15)
        {
            timerUntillKill = 0;
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
        hand.SetActive(true);
        cameraChanger.Play(camName);
        flashlight.SetActive(false);
        playerLook.enabled = false;
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
        yield return new WaitForSeconds(0.5f);
        playermovement.enabled = true;
        playerLook.enabled = true;
        boxCol.enabled = true;
        flashlight.SetActive(true);
        hand.SetActive(false);
    }
}
