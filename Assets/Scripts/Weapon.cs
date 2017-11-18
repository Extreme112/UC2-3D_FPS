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
    public float shootDelay;

    //Ammo 
    private int ammo; 
    public float reloadTime;

    public int maxClipCapacity; 
    private int currentClipCapacity;
    public int numberOfClips; 

    void Start() {
        audioSource = GetComponent<AudioSource>();
        ammo = maxClipCapacity * numberOfClips; 
        currentClipCapacity = maxClipCapacity;
    }

	// Update is called once per frame
	void Update () {
        if (isAutomatic && Input.GetButton("Fire1") && canFire) { 
            Fire();
        }
        if (!isAutomatic && Input.GetButtonDown("Fire1") && canFire) { 
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload());
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
            currentClipCapacity--;  //subtract 1 from current clip
        }        
    }

    IEnumerator FireLimit() {
        canFire = false;
        yield return new WaitForSeconds(shootDelay);
        canFire = true;
    }

    IEnumerator Reload() {
        if (numberOfClips > 0) {
            canFire = false;
            currentClipCapacity = maxClipCapacity;
            numberOfClips--;
            yield return new WaitForSeconds(reloadTime);
            canFire = true;
        }
    }

    //add one more clip to our total ammo capacity
    public void AddClip() {
        ammo = ammo + maxClipCapacity;
    }
}
