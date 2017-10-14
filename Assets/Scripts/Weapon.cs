using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string wepName;
    public int damage;
    public GameObject oCamera;
    public float range;
    //reload speed, fireRate, ammo count
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update () {
        //----SHOOOTING------------
        if (Input.GetButtonDown("Fire1")) {
            //Play Pistol Shot sound effect
            audioSource.clip = audioClips[0];
            audioSource.Play();
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
