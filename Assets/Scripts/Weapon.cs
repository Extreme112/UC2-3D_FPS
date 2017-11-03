using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string wepName;
    public int damage;
    public GameObject oCamera;
    public float range;
    //Effects
    public GameObject bulletImpact;
    public ParticleSystem muzzleFlash;
    private AudioSource audioSource; //audiosource
    //Fire Rate
    bool canFire = true;
    public float shootDelay = 2;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        //----SHOOOTING------------
        if (Input.GetButtonDown("Fire1") && canFire) {
            Fire();
        }
    }

    void Fire() {
        StartCoroutine(FireLimit());
        //play audio here
        audioSource.Play();
        //Muzzle Flash
        muzzleFlash.Stop();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(oCamera.transform.position, oCamera.transform.forward, out hit, range)) {
            //Show bullet impact
            GameObject impact = Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            if (hit.collider.CompareTag("Enemy")) {
                //Deal damage to enemy
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    IEnumerator FireLimit() {
        canFire = false;
        yield return new WaitForSeconds(shootDelay);
        canFire = true;
    }
}
