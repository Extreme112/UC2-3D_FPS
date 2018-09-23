using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for the explosion.
//Add this to your rocket shell object
public class RocketProjectile : MonoBehaviour {
    public int damage;
    public int radius;
    public GameObject weaponExplosionEffect; //this will be the explosion effect

    //this is for the explosion sound
    private AudioSource source;

    private void Start() {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        Collider[] objects = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in objects) {
            if (c.CompareTag("Enemy")) {
                c.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            //if you want to hurt yourself
            else if (c.CompareTag("Player")) {
                c.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
        
        Instantiate(weaponExplosionEffect, transform.position, Quaternion.identity);
        StartCoroutine(StartDestroy());
        
    }
    IEnumerator StartDestroy() {
        source.Stop();
        source.Play(); //play sound
        this.enabled = false;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject); //destroy the rocket when it touches something
    }
}
