using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightPathShow : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PathFade fadeing;

    void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 1f, transform.forward, out hit, 4f, layerMask))
        {
            if (hit.collider.gameObject)
            {
                Debug.Log("True");
                fadeing.fadeIn = true;
            }
        }
        else
        {
            Debug.Log("False");
            fadeing.fadeIn = false;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 4;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
