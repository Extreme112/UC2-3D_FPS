using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    public float sensitivity;
    public GameObject camera; // looking up and down

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        float xspeed = Input.GetAxis("Mouse X"); //get how fast you are moving your mouse horizontally
        transform.Rotate(Vector3.up * xspeed * sensitivity * Time.deltaTime);

        float yspeed = Input.GetAxis("Mouse Y"); //looking up and down
        print(camera.transform.eulerAngles.x);
        camera.transform.Rotate(Vector3.left * yspeed * sensitivity * Time.deltaTime); //rotate camera
        
            

    }
}
