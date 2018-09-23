using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public int damage;
    public float radius;
    public GameObject explosionEffect;
    public float delay;
	// Use this for initialization
	void Start () {
        StartCoroutine(Explode()); //I forgot this one
	}

    IEnumerator Explode() {
        yield return new WaitForSeconds(delay);
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
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    //write this if you want to see the actual explosion radius in the scene
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        //Use the same vars you use to draw your Overlap Sphere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
