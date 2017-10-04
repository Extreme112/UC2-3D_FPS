using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float jumpSpeed;
    public float speed;
    Vector3 moveDirection;
    CharacterController characterController;
    public float gravity;
    private float vsp = 0;

    void Start() {
        characterController = GetComponent<CharacterController>(); //new
    }
	
	// Update is called once per frame
	void Update () {

        ////----- CAN MOVE WHILE MIDAIR ---//
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);
        //if (characterController.isGrounded) {
        //    Vector3 tempDirection = transform.TransformDirection(moveDirection.x, 0, moveDirection.z);
        //    moveDirection = new Vector3(tempDirection.x, tempDirection.y, tempDirection.z);
        //    //moveDirection *= speed;

        //    //moveDirection.y = 0;
        //    if (Input.GetButton("Jump"))
        //        moveDirection.y = jumpSpeed;
        //}
        //moveDirection.y -= gravity * Time.deltaTime;
        //characterController.Move(moveDirection * Time.deltaTime);
        //----- CANT MOVE WHILE MIDAIR ---//
        if (characterController.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
