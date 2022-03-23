using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Info")]
    public Transform body;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        body.transform.rotation = Quaternion.Euler(Quaternion.identity.x, transform.eulerAngles.y, Quaternion.identity.z);
    }
}
