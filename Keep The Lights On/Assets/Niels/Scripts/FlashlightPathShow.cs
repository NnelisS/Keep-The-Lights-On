using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightPathShow : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.1f, transform.forward, out hit, 4f, layerMask))
        {
            Collider[] hitColliders = Physics.OverlapSphere(hit.transform.position, 1f, layerMask);
            if (hitColliders != null && hitColliders.Length > 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    FootstepGlow footstep = hitColliders[i].gameObject.GetComponent<FootstepGlow>();
                    if (footstep != null)
                    {
                        footstep.FootstepFade();
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 4;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
