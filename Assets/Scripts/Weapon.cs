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
    public ParticleSystem muzzleFlash; //this is our muzzle flash particle system

    public bool isAutomatic = false; 
    bool canFire = true; 
    public float delay; 

    //Ammo 
    public int ammo; //this is the weapons current ammo
    public int maxClipCapacity; //this is the number of bullet in a clip
    public int intialNumOfClips; //num of clips when the game starts

    void Start() {
        audioSource = GetComponent<AudioSource>();
        ammo = maxClipCapacity * intialNumOfClips; //initially, 2 clips worth of ammo available for the weapon
    }

	// Update is called once per frame
	void Update () {
        if (isAutomatic && Input.GetButton("Fire1") && canFire) { //single shot
            Fire();
        }
        if (!isAutomatic && Input.GetButtonDown("Fire1") && canFire) { //full auto
            Fire();
        }
    }

    //Fire function
    void Fire() {
        if (ammo > 0) {
            StartCoroutine(FireLimit());
            //Play the muzzle flash effect
            if (muzzleFlash.isStopped) {
                muzzleFlash.Play();
            }

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
            ammo--;  //subtract 1 from current ammo
        }        
    }

    IEnumerator FireLimit() {
        canFire = false;
        yield return new WaitForSeconds(delay);
        canFire = true;
    }

    //add one more clip to our total ammo capacity
    public void AddClip() {
        ammo = ammo + maxClipCapacity;
    }
}
