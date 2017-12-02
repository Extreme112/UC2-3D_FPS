using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRocket : MonoBehaviour {
    public int damage;
    public float radius;
    public GameObject explosionEffect;
    public float explosionForce;
    // Use this for initialization
    private void OnCollisionEnter(Collision collision) {
        Explode();
    }

    private void Explode() {
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
}
