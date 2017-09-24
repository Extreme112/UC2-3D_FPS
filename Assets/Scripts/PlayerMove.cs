using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    Vector3 moveDirection;
    CharacterController characterController;
    public float gravity;

    void Start() {
        characterController = GetComponent<CharacterController>(); //new
    }
	
	// Update is called once per frame
	void Update () {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        
        if (!characterController.isGrounded) {
            moveDirection.y -= gravity * Time.deltaTime; //add gravity
        } else {
            moveDirection.y = 0;
        }

        characterController.Move(moveDirection * Time.deltaTime);  
    }


}
