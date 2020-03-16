using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] float jumpHeight = 5f;

    [SerializeField] Transform bottom;
    [SerializeField] LayerMask groundMask;

    CharacterController controller;

    Vector3 velocity;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpAndDown();

        isGrounded = Physics.CheckSphere(bottom.position, groundDistance, groundMask);

        
    }


    private void UpAndDown()
    {
        if(isGrounded && CrossPlatformInputManager.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
    }

    private void Move()
    {
        float moveX = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveZ = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);
    }
}
