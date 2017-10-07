using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    public float sensitivity;
    public GameObject camera; // looking up and down

    // -- fix looking up without over rotating
    Vector3 originalRotation;
    float yRotation;

    // Use this for initialization
    void Start () {
        originalRotation = transform.localRotation.eulerAngles;
        yRotation = originalRotation.y;
    }
	
	// Update is called once per frame
	void Update () {
        //This rotates sideways
        float xspeed = Input.GetAxis("Mouse X"); //get how fast you are moving your mouse horizontally
        transform.Rotate(Vector3.up * xspeed * sensitivity * Time.deltaTime);

        //--------------this rotates up and down
        float yspeed = -Input.GetAxis("Mouse Y");
        yRotation += yspeed * sensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80, 80);

        Quaternion localRotation = Quaternion.Euler(yRotation, 0, 0);
        camera.transform.localRotation = localRotation;
        //---------------------

    }
}
