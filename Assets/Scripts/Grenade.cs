using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public int damage;
    public float explosionDelay;
    public float radius;
    public GameObject explosionEffect;
    public float explosionForce;
    // Use this for initialization
    void Start() {
        StartCoroutine(Explode());
    }
    IEnumerator Explode() {
        yield return new WaitForSeconds(explosionDelay);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in hitColliders) {
            if (c.CompareTag("Enemy")) {
                c.GetComponent<EnemyHealth>().TakeDamage(damage);
                if (c.GetComponent<Rigidbody>()) {
                    c.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, radius, 0.0F, ForceMode.Impulse);
                }
            }
        }
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap Sphere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
