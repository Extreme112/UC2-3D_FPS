using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 10;
    Vector3 moveDirection;
    CharacterController characterController;
    public float gravity = 100;
    public float jumpSpeed = 200; // we will set this in the Unity editor

    void Start() {
        characterController = GetComponent<CharacterController>(); //new
    }
	
	// Update is called once per frame
	void Update () {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded) {
            moveDirection.y = jumpSpeed; //then we will jump
        }

        moveDirection.y -= gravity * Time.deltaTime; //add gravity
        characterController.Move(moveDirection * Time.deltaTime);  
    }


}
