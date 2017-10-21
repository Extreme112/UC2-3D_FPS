using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string wepName;
    public int damage;
    public GameObject oCamera;
    public float range;
    private AudioSource audioSource; //audiosource

    void Start() {
        audioSource = GetComponent<AudioSource>();
        //this is the code that actually plays the audio, but it doesn't belong here
        //where should we put this?
        
    }

	// Update is called once per frame
	void Update () {
        //----SHOOOTING------------
        if (Input.GetButtonDown("Fire1")) {
            //play audio here
            audioSource.Play(); //this plays the shooting sound
            RaycastHit hit;
            if (Physics.Raycast(oCamera.transform.position, oCamera.transform.forward, out hit, range)) {
                //  ----------Deal damage to an enemy-------
                if (hit.collider.CompareTag("Enemy")) {
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
}
