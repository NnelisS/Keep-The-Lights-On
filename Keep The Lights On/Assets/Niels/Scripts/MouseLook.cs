using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Settings")]
    [Range(50, 250)] public float mouseSensitivityX = 100;
    [Range(50, 250)] public float mouseSensitivityY = 100;
    public float sensitivityMultiplier = 2.5f;

    [Header("Info")]
    public Transform body;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        SensitivityScrollChange();

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }

    #region Sensitivy Scroll
    private void SensitivityScrollChange()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mouseSensitivityX += sensitivityMultiplier * sensitivityMultiplier;
            mouseSensitivityY += sensitivityMultiplier * sensitivityMultiplier;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mouseSensitivityX -= sensitivityMultiplier * sensitivityMultiplier;
            mouseSensitivityY -= sensitivityMultiplier * sensitivityMultiplier;
        }

        mouseSensitivityX = Mathf.Clamp(mouseSensitivityX, 50f, 250f);
        mouseSensitivityY = Mathf.Clamp(mouseSensitivityY, 50f, 250f);
    }
    #endregion
}
