using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string wepName;
    public int damage;
    public GameObject oCamera;
    public float range;
    private AudioSource audioSource; 
    //Bullet Impacts
    public GameObject bulletImpact; //this is our bullet impact particle system

    public bool isAutomatic = false; //by default, our weapon is single fire only
    bool canFire = true; //initially, we can shoot
    public float delay; //delay between each shot

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        //=======================================
        if (isAutomatic && Input.GetButton("Fire1") && canFire) { //single shot
            Fire();
        }
        if (!isAutomatic && Input.GetButtonDown("Fire1") && canFire) { //full auto
            Fire();
        }
        //====================================
    }

    void Fire() {

        StartCoroutine(FireLimit());
        //play audio here
        audioSource.Play(); //this plays the shooting sound
        RaycastHit hit;
        if (Physics.Raycast(oCamera.transform.position, oCamera.transform.forward, out hit, range)) {

            //Create the bullet impact
            Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));

            //  ----------Deal damage to an enemy-------
            if (hit.collider.CompareTag("Enemy")) {
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }
        }
        
    }

    IEnumerator FireLimit() {
        canFire = false;
        yield return new WaitForSeconds(delay);
        canFire = true;
    }
}
