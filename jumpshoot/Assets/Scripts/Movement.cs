using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    /*Used Brackey's Tutorial
     https://www.youtube.com/watch?v=_QajrabyTJc
     */
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 10.0f;
    
    public float jumpHeight = 5.0f;
    private float gravity = -9.18f;
    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Gravity Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        
        //Gravity
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);
                
        
        //WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        playerVelocity = transform.right * x + transform.forward * z;
        controller.Move(playerVelocity * playerSpeed * Time.deltaTime);
        
        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //Debug.Log("Character position is: " + transform.position);
    }
}