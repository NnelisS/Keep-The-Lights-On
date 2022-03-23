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

    [Header("Camera")]
    public Animator cameraChanger;

    [Header("Window")]
    public BoxCollider boxCol;

    [Header("Canvas")]
    public Animator fade;

    public bool movementEnabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
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

    private void WindowIsPulledDown()
    {
        if (transform.localPosition.y <= 0.3f)
        {
            activateWindow = false;
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
        cameraChanger.Play("Cam 3");
        flashlight.SetActive(false);
        playerLook.enabled = false;
        boxCol.enabled = false;
        playermovement.enabled = false;
        fade.Play("FastFade");
        yield return new WaitForSeconds(0.5f);
        movementEnabled = true;
    }

    public IEnumerator OutWindow()
    {
        cameraChanger.Play("CameraChange");
        movementEnabled = false;
        fade.Play("FastFade");
        yield return new WaitForSeconds(0.5f);
        playermovement.enabled = true;
        playerLook.enabled = true;
        boxCol.enabled = true;
        flashlight.SetActive(true);
    }
}
