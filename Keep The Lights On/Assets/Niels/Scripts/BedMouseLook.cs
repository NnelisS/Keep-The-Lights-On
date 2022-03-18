using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedMouseLook : MonoBehaviour
{
    [Header("Settings")]
    [Range(50, 250)] public float mouseSensitivityX = 100;
    [Range(50, 250)] public float mouseSensitivityY = 100;
    public float sensitivityMultiplier = 2.5f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 14f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -220f, -140f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
