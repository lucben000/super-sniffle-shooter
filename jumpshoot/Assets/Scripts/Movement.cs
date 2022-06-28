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
    public float jumpHeight = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        playerVelocity = transform.right * x + transform.forward * z;

        controller.Move(playerVelocity * playerSpeed * Time.deltaTime);
        
        //Debug.Log("Character position is: " + transform.position);
    }
}