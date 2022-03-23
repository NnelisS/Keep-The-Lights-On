using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [Header("Side Info")]
    public InToBed inToBed;

    [Header("Player Info")]
    public GameObject flashlight;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;

    [Header("Camera Info")]
    public Camera mainCamera;
    public Camera bedCamera;
    public Animator fade;
    public Animator cameraChanger;

    public Animator eyes;
    public Animator bedSheet;

    private bool getIntoBed = false;
    private bool inBed = false;
    private bool cantGetOut = false;
    private bool closing = true;
    private bool opening = false;

    private BoxCollider boxCol;


    private void Start()
    {
        boxCol = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        CloseEyes();
        OpenEyes();

        if (inToBed.intoBed == true)
        {
            getIntoBed = true;
        }
        else if (inToBed.intoBed == false)
        {
            getIntoBed = false;
        }

        if (inBed == true && cantGetOut == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(OutBed());
            }
        }
    }

    public void OnMouseDown()
    {
        if (getIntoBed == true && inBed == false)
        {
            if (cantGetOut == false)
            {
                StartCoroutine(InBed());
            }
        }
        else if (getIntoBed == true)
        {

        }
    }

    private void CloseEyes()
    {
        if (inBed && opening == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                StartCoroutine(CloseEyesNow());
                opening = false;
            }
        }
    }

    private void OpenEyes()
    {
        if (inBed && closing == true)
        {
            if (Input.GetKeyUp(KeyCode.G))
            {
                StartCoroutine(OpenEyesNow());
                closing = false;
            }
        }
    }

    private IEnumerator CloseEyesNow()
    {
        cantGetOut = true;
        eyes.Play("EyesClose");
        yield return new WaitForSeconds(2f);
        opening = false;
        closing = true;
    }    
    
    private IEnumerator OpenEyesNow()
    {
        eyes.Play("EyesOpen");
        yield return new WaitForSeconds(2f);
        closing = false;
        opening = true;
        cantGetOut = false;
    }

    private IEnumerator InBed()
    {
        boxCol.enabled = false;
        cameraChanger.Play("Cam 2");
        mouseLook.enabled = false;
        playerMovement.enabled = false;
        flashlight.SetActive(false);
        bedSheet.Play("BedSheetClose");
        cantGetOut = true;
        inBed = true;
        fade.Play("Fade");
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(1f);
        cantGetOut = false;
    }

    private IEnumerator OutBed()
    {
        cameraChanger.Play("CameraChange");
        bedSheet.Play("BedSheetOpen");
        inBed = false;
        fade.Play("Fade");
        yield return new WaitForSeconds(1f);
        flashlight.SetActive(true);
        yield return new WaitForSeconds(1f);
        bedSheet.Play("BedSheetOpenUp");
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        boxCol.enabled = true;
    }
}
