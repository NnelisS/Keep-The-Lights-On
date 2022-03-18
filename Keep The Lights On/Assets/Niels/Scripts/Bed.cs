using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [Header("Side Info")]
    public InToBed inToBed;

    [Header("Camera Info")]
    public Camera mainCamera;
    public Camera bedCamera;
    public Animator fade;

    public Animator eyes;

    public bool getIntoBed = false;
    public bool inBed = false;
    public bool cantGetOut = false;
    public bool closing = true;
    public bool opening = false;

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
        cantGetOut = true;
        inBed = true;
        fade.Play(0);
        yield return new WaitForSeconds(1f);
        mainCamera.enabled = false;
        bedCamera.enabled = true; 
        yield return new WaitForSeconds(1f);
        cantGetOut = false;
    }

    private IEnumerator OutBed()
    {
        inBed = false;
        fade.Play(0);
        yield return new WaitForSeconds(1f);
        bedCamera.enabled = false;
        mainCamera.enabled = true;
    }
}
