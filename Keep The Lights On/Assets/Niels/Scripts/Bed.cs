using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    [Header("eyeClose Info")]
    public float timeEyesAreClosed;
    private bool eyesClosed = false;

    [Header("Side Info")]
    public InToBed inToBed;

    [Header("Player Info")]
    public GameObject flashlight;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    public GameObject furLight;
    public AudioSource footstep;

    [Header("Camera Info")]
    public Camera mainCamera;
    public Animator fade;
    public Animator cameraChanger;

    [Header("Bed")]
    public Animator eyes;
    public Animator bedSheet;
    public float timeUnderBlanket;

    [Header("Canvas")]
    public GameObject bedIcon;
    public GameObject underBlanketP;
    public Animator underBlanketAnim;

    [Header("Sounds")]
    public AudioSource blanketBreath;
    public AudioSource lastBreath;
    public AudioSource underBlanketAudio;
    public Animator ambient;

    private bool getIntoBed = false;
    private bool inBed = false;
    private bool cantGetOut = false;
    private bool closing = false;
    private bool opening = true;
    public bool underBlanket = false;
    private bool usable = true;

    private BoxCollider boxCol;


    private void Start()
    {
        boxCol = GetComponent<BoxCollider>();
        StartCoroutine(InBed());
    }
    private void Update()
    {
        CloseEyes();
        OpenEyes();
        UnderBlanket();
        BreathingUnderBlanket();

        if (underBlanket == true)
        {
            timeUnderBlanket += Time.deltaTime;
            underBlanketP.SetActive(true);
            blanketBreath.enabled = true;
            underBlanketAnim.Play("UnderBlanketPanel");
            underBlanketAnim.Play("UnderBlanketPanel");
        }
        else if (underBlanket == false)
        {
            timeUnderBlanket -= Time.deltaTime;
            underBlanketP.SetActive(false);
            underBlanketAnim.Play("New State");
        }
        if (timeUnderBlanket >= 9)
        {
            StartCoroutine(BlanketKill());
            blanketBreath.enabled = false;
            Debug.Log("Ur DED blanket");
            usable = false;

        }
        if (timeUnderBlanket <= 0)
        {
            timeUnderBlanket = 0;
            blanketBreath.enabled = false;
        }

        if (eyesClosed == true)
        {
            timeEyesAreClosed += Time.deltaTime;
        }

        if (inToBed.intoBed == true)
        {
            getIntoBed = true;
        }
        else if (inToBed.intoBed == false)
        {
            getIntoBed = false;
        }

        if (inBed == true && cantGetOut == false && underBlanket == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(OutBed());
            }
        }
    }

    #region breathing Blanket
    private void BreathingUnderBlanket()
    {
        if (timeUnderBlanket <= 1)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.1f);
        }
         if (timeUnderBlanket >= 2)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.2f);
        }
         if (timeUnderBlanket >= 3)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.3f);
        }
         if (timeUnderBlanket >= 4)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.4f);
        }
         if (timeUnderBlanket >= 5)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.5f);
        }
         if (timeUnderBlanket >= 6)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.6f);
        }
         if (timeUnderBlanket >= 7)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.7f);
        }
         if (timeUnderBlanket >= 8)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.8f);
        }
         if (timeUnderBlanket >= 9)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 0.9f);
            lastBreath.enabled = true;
        }
        if (timeUnderBlanket >= 10)
        {
            blanketBreath.volume = Mathf.Lerp(0.0f, 1.0f, 1.0f);
        }
    }
    #endregion

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

    private void OnMouseEnter()
    {
        if (getIntoBed == true && inBed == false)
        {
            bedIcon.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (getIntoBed == true && inBed == false)
        {
            bedIcon.SetActive(false);
        }
    }

    #region Blanket state
    private void UnderBlanket()
    {
        if (inBed == true && opening == true)
        {
            if (underBlanket == false && usable == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(UnderBlanketIn());
                }
            }
            else if (underBlanket == true && usable == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(UnderBlanketOut());
                }
            }
        }
    }
    #endregion

    #region eye state
    private void CloseEyes()
    {
        if (inBed && opening == true && underBlanket == false)
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
    #endregion

    #region eyes
    private IEnumerator CloseEyesNow()
    {
        cantGetOut = true;
        eyes.Play("EyesClose");
        yield return new WaitForSeconds(2f);
        eyesClosed = true;
        opening = false;
        closing = true;
    }    
    
    private IEnumerator OpenEyesNow()
    {
        eyes.Play("EyesOpen");
        eyesClosed = false;
        yield return new WaitForSeconds(2f);
        closing = false;
        opening = true;
        cantGetOut = false;
    }
    #endregion

    #region bed
    private IEnumerator InBed()
    {
        footstep.enabled = false;
        boxCol.enabled = false;
        bedIcon.SetActive(false);
        cameraChanger.Play("Cam 2");
        mouseLook.enabled = false;
        playerMovement.enabled = false;
        flashlight.SetActive(false);
        bedSheet.Play("BedSheetClose");
        cantGetOut = true;
        inBed = true;
        fade.Play("Fade");
        yield return new WaitForSeconds(1f);
        bedSheet.Play("BedSheetOpenClose");
        furLight.SetActive(true);
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
        furLight.SetActive(false);
        yield return new WaitForSeconds(1f);
        bedSheet.Play("BedSheetOpenUp");
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        boxCol.enabled = true;
    }
    #endregion

    #region blanket
    private IEnumerator UnderBlanketIn()
    {
        bedSheet.Play("UnderBlanket");
        fade.Play("FastFade");
        usable = false;
        underBlanketAudio.enabled = true;
        yield return new WaitForSeconds(1);
        underBlanket = true;
        usable = true;
        yield return new WaitForSeconds(1);
        underBlanketAudio.enabled = false;
    }

    private IEnumerator UnderBlanketOut()
    {
        bedSheet.Play("UnderBlanketOut");
        fade.Play("FastFadeOut");
        usable = false;
        underBlanketAudio.enabled = true;
        yield return new WaitForSeconds(1);
        underBlanket = false;
        usable = true;
        yield return new WaitForSeconds(1);
        underBlanketAudio.enabled = false;
    }

    private IEnumerator BlanketKill()
    {
        fade.Play("Dead");
        ambient.Play("Ambient Fade");
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("YouLoseBlanket");
    }
    #endregion
}
