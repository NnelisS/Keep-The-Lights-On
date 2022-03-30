using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [Header("Settings")]
    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("ground Info")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Sound")]
    public AudioSource footstepSound;

    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        GroundCheck();
        MoveCheck();

        // get input axis
        float x = Input.GetAxis("Horizontal");       
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move += Physics.gravity;

        // use character controller to move around
        controller.Move(move * speed * Time.deltaTime);
    }

    private void MoveCheck()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
        }
    }

    #region GroundCheck
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }
        else
        {
        }
    }
    #endregion
}