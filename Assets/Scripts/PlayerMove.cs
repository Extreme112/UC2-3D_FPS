using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float gravity;
    public float jumpSpeed; // we will set this in the Unity editor
    public float speed;
    Vector3 moveDirection;
    CharacterController characterController;


    void Start() {
        characterController = GetComponent<CharacterController>(); //new
    }
	
	// Update is called once per frame
	void Update () {
        if (characterController.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed; //then we will jump
            }
        }

        moveDirection.y -= gravity * Time.deltaTime; //add gravity
        characterController.Move(moveDirection * Time.deltaTime);  
    }
}
