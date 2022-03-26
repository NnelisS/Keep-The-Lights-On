using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLive : MonoBehaviour
{
    [Header("Player Info")]
    public Animator eyeFade;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FootstepPath"))
        {
            eyeFade.Play("KillFade");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FootstepPath"))
        {
            eyeFade.Play("NormalFade");
        }
    }
}
