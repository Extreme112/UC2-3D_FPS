using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string wepName;
    public int damage;
    public GameObject oCamera;
    public float range;
    private AudioSource audioSource;

    public AudioClip shootSound; //this will be our shoot sound
    public AudioClip reloadSound; //this will be our reload sound
     
    //Bullet Impacts
    public GameObject bulletImpact; //this is our bullet impact particle system
    public ParticleSystem muzzleFlash; //this is our muzzle flash particle system

    public bool isAutomatic = false; 
    bool canFire = true; 
    public float delay; 

    //Ammo 
    //public int ammo; GET RID OF THIS
    public int maxClipCapacity; //this is how many bullets a clip can hold
    public int numOfClips; //rename to numOfClips
    public int currentClipCapacity; //this is how many bullets the current clip has
    public float reload_delay; //this is how long it takes to reload the weapon

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootSound;
    }

	// Update is called once per frame
	void Update () {
        if (isAutomatic && Input.GetButton("Fire1") && canFire) { //single shot
            Fire();
        }
        if (!isAutomatic && Input.GetButtonDown("Fire1") && canFire) { //full auto
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R) && numOfClips > 0) {
            //Reload
            StartCoroutine(Reloading()); //this actually lets us reload
            numOfClips--; //subtract one from our current number of clips
        }
    }

    //Fire function
    void Fire() {
        if (currentClipCapacity > 0) {
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
            currentClipCapacity--;  //subtract 1 from current ammo
        }        
    }

    IEnumerator FireLimit() {
        canFire = false;
        yield return new WaitForSeconds(delay);
        canFire = true;
    }

    IEnumerator Reloading() {
        audioSource.clip = reloadSound;
        audioSource.Stop();
        audioSource.Play();
        canFire = false; //disable player from firing
        currentClipCapacity = maxClipCapacity; //"reload"
        yield return new WaitForSeconds(reloadSound.length); //wait  for a certain delay
        canFire = true; //let the player fire again

        audioSource.clip = shootSound; //I FORGOT THIS PART
    }


    public void AddClip() {
        numOfClips++; //increment the num of clips you have
    }
}
