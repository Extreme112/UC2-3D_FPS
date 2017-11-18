using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour {
    public int numOfGrenades;
    public int force;
    public GameObject grenadePrefab;
    public GameObject mainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3")) {
            if (numOfGrenades > 0) {
                //Throw the grenade
                GameObject go = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * force, ForceMode.Impulse);
                numOfGrenades--;
            }
        }
	}
}
