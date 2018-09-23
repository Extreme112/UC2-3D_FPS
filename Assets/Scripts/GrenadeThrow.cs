using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make sure your grenade has a rigidbody
public class GrenadeThrow : MonoBehaviour {
    public int numOfGrenades;
    public float throwForce;
    public GameObject grenadePrefab;
    //we need the main camera to figure out the direction the player is looking
    public GameObject mainCamera; 
	
	// Update is called once per frame
	void Update () {
        //This checks for middle mouse click, if you want a different key, G for example
        //you can try: Input.GetKeyDown(KeyCode.G)
        if (Input.GetButtonDown("Fire3")) {
            GameObject go = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * throwForce, ForceMode.Impulse);
        }
	}
}
