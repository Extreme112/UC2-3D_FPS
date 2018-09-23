using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 10;
    public Vector3 moveDirectionWorld;
    public Vector3 moveDirectionLocal;
    public Vector3 moveDirectionFinal;
    CharacterController characterController;
    public float gravity = 100;
    public float jumpSpeed = 200; // we will set this in the Unity editor

    void Start() {
        characterController = GetComponent<CharacterController>(); //new
    }
	
	// Update is called once per frame
	void Update () {
        if (characterController.isGrounded) {
            moveDirectionLocal = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirectionWorld = transform.TransformDirection(moveDirectionLocal);
            moveDirectionFinal = speed * moveDirectionWorld;

            if (Input.GetButton("Jump")) {
                moveDirectionFinal.y = jumpSpeed; //then we will jump
            }
        }

        moveDirectionFinal.y -= gravity * Time.deltaTime; //add gravity
        characterController.Move(moveDirectionFinal * Time.deltaTime);  
    }
}
