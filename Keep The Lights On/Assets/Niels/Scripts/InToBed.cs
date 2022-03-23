using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InToBed : MonoBehaviour
{
    public bool intoBed = false;
    public Animator bedSheet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            intoBed = true;
            bedSheet.Play("BedSheetOpenUp");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            intoBed = false;
            bedSheet.Play("BedSheetOpenClose");
        }
    }
}
